using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 一.下载资源
///     1.下载资源文件，AB包等
///     2.热更新dll
///     3.AOT泛型补充元数据dll
///     
/// 二.给AOT Dll补充元数据
/// 三.通过实例化一个预制体运行热更新代码
/// </summary>
public class LoadDll : MonoBehaviour
{
    // 补充元数据dll的列表
    // 通过RuntimeApi.LoadMetadataForAOTAssembly()函数来补充AOT泛型的原始元数据
    public static List<string> AOTMetaAssemblyNames = new List<string>()
    {
        "mscorlib.dll",
        "System.dll",
        "System.Core.dll",
        "Unity.Mono.dll",
        "Unity.ThirdParty.dll",
    };


    void Start()
    {
        //StartCoroutine(DownLoadAssets(StartGame));
    }


    void StartGame()
    {
        LoadMetadataForAOTAssemblies();


    }

    private static Dictionary<string, byte[]> s_assetDatas = new Dictionary<string, byte[]>();

    public static byte[] GetAssetData(string dllName)
    {
        return s_assetDatas[dllName];
    }

    private string GetWebRequestPath(string asset)
    {
        var path = $"{Application.streamingAssetsPath}/{asset}";

        if (!path.Contains("://"))
            path = "file://" + path;

        if (path.EndsWith(".dll"))
            path += ".bytes";

        return path;
    }

    private IEnumerator DownLoadAssets(Action onDownloadComplete)
    {
        var assets = new List<string>
        {
            "Assembly-CSharp.dll;"
        }.Concat(AOTMetaAssemblyNames);

        foreach (var asset in assets)
        {
            var dllPath = GetWebRequestPath(asset);
            Debug.Log($"start download asset {dllPath}");
            var www = UnityWebRequest.Get(dllPath);
            yield return www.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
#else
            if(www.isHttpError || www.idNetWorkError)
            {
            Debug.LogError(www.error);
            }
#endif
            else
            {
                //Or retrieve result as binary data
                var assetData = www.downloadHandler.data;
                Debug.Log($"dll:{asset} size:{assetData.Length}");
                s_assetDatas[asset] = assetData;
            }
        }

        onDownloadComplete();
    }


    /// <summary>
    /// 为aot assembly加载原始metadata， 这个代码放aot或者热更新都行。
    /// 一旦加载后，如果AOT泛型函数对应native实现不存在，则自动替换为解释模式执行
    /// </summary>
    private static void LoadMetadataForAOTAssemblies()
    {
        /// 注意，补充元数据是给AOT dll补充元数据，而不是给热更新dll补充元数据。
        /// 热更新dll不缺元数据，不需要补充，如果调用LoadMetadataForAOTAssembly会返回错误
        /// 
        HomologousImageMode mode = HomologousImageMode.SuperSet;
        foreach (var aotDllName in AOTMetaAssemblyNames)
        {
            byte[] dllBytes = GetAssetData(aotDllName);
            // 加载assembly对应的dll，会自动为它hook。一旦aot泛型函数的native函数不存在，用解释器版本代码
            LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
            Debug.Log($"LoadMetadataForAOTAssembly:{aotDllName}. mode:{mode} ret:{err}");
        }
    }
}