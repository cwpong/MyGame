//using ET;
//using System;
//using System.Collections;
//using UnityEngine;
//using YooAsset;

//public class Test : MonoBehaviour
//{
//    /// <summary>
//    /// ��Դϵͳ����ģʽ
//    /// </summary>
//    public const EPlayMode MODEL = EPlayMode.HostPlayMode;

//    // Start is called before the first frame update
//    void Start()
//    {
//        UnityEngine.Debug.LogWarning("��ʼ����");
//        StartCoroutine(BeginDownPatch());
//        UnityEngine.Debug.LogWarning("���ؽ���");
//    }

//    private static IEnumerator BeginDownPatch()
//    {
        
//        // ��ʼ����Դϵͳ
//        UnityEngine.Debug.LogWarning("��ʼ��1");
//        YooAssets.Initialize();
//        UnityEngine.Debug.LogWarning("��ʼ��2");
//        YooAssets.SetOperationSystemMaxTimeSlice(30);

//        // ���ø���Դ��ΪĬ�ϵ���Դ��, ����ʹ��YooAssets��ؼ��ؽӿڸ���Դ������
//        var package = YooAssets.CreateAssetsPackage("DefaultPackage");
//        YooAssets.SetDefaultAssetsPackage(package);
//        UnityEngine.Debug.LogWarning($"��ȡ��Դ�汾�ɹ� name = {package.PackageName}");
//        // �༭��ģʽ
//        if (MODEL == EPlayMode.EditorSimulateMode)
//        {
//            var initParameters = new EditorSimulateModeParameters();
//            initParameters.SimulatePatchManifestPath = EditorSimulateModeHelper.SimulateBuild("DefaultPackage");
//            yield return package.InitializeAsync(initParameters);

//        }
//        else if (MODEL == EPlayMode.OfflinePlayMode)
//        {
//            var initParameters = new OfflinePlayModeParameters();
//            yield return package.InitializeAsync(initParameters);

//        }
//        else if (MODEL == EPlayMode.HostPlayMode)
//        {
//            UnityEngine.Debug.LogWarning("��������");
//            var initParameters = new HostPlayModeParameters();
//            initParameters.QueryServices = new QueryStreamingAssetsFileServices();
//            initParameters.DefaultHostServer = "http://192.168.31.236:8080/CDN//V1.0.6";
//            initParameters.FallbackHostServer = "http://192.168.31.236:8080/CDN/V1.0.6";
//            yield return package.InitializeAsync(initParameters);
//        }

        
//        UnityEngine.Debug.LogWarning($"package Name = {package.PackageName}");
//        // ��ȡ��Դ�汾
//        var operation = package.UpdatePackageVersionAsync();
//        yield return operation;


//        UnityEngine.Debug.LogWarning($"EOperationStatus {operation.Status}");
//        if (operation.Status != EOperationStatus.Succeed)
//        {
//            //����ʧ��
//            UnityEngine.Debug.LogError(operation.Error);
//            yield break;
//        }

//        string packageVersion = operation.PackageVersion;
//        UnityEngine.Debug.Log($"Updated package Version : {packageVersion}");
//        // ���²����嵥
//        var updateMainfest = package.UpdatePackageManifestAsync(packageVersion);
//        yield return updateMainfest;

//        if (operation.Status != EOperationStatus.Succeed)
//        {
//            UnityEngine.Debug.LogError(operation.Error);
//            yield break;
//        }

//        UnityEngine.Debug.LogWarning("���²����嵥���ɹ�");
//        // ���ز�����
//        yield return Download();

//        Scene zoneScene = SceneFactory.CreateZoneScene(1, "Game", Game.Scene);
//        Game.EventSystem.Publish(new ET.EventType.LoadPatchFinish() { ZoneScene = zoneScene });
//    }



//    private static IEnumerator Download()
//    {
//        int downloadingMaxNum = 10;
//        int failedTryAgain = 3;
//        int timeout = 60;
//        var package = YooAssets.GetAssetsPackage("DefaultPackage");
//        var downloader = package.CreatePatchDownloader(downloadingMaxNum, failedTryAgain, timeout);

//        //û����Ҫ���ص���Դ
//        if (downloader.TotalDownloadCount == 0)
//        {
//            yield break;
//        }

//        //��Ҫ���ص��ļ��������ܴ�С
//        int totalDownloadCount = downloader.TotalDownloadCount;
//        long totalDownloadBytes = downloader.TotalDownloadBytes;

//        //ע��ص�����
//        downloader.OnDownloadErrorCallback = OnDownloadErrorFunction;
//        downloader.OnDownloadProgressCallback = OnDownloadProgressUpdateFunction;
//        downloader.OnDownloadOverCallback = OnDownloadOverFunction;
//        downloader.OnStartDownloadFileCallback = OnStartDownloadFileFunction;

//        //��������
//        downloader.BeginDownload();
//        yield return downloader;

//        //������ؽ��
//        if (downloader.Status == EOperationStatus.Succeed)
//        {
//            //���سɹ�
//        }
//        else
//        {
//            //����ʧ��
//        }
//    }


//    /// <summary>
//    /// ��ʼ�����ļ�
//    /// </summary>
//    /// <param name="fileName"></param>
//    /// <param name="sizeBytes"></param>
//    /// <exception cref="NotImplementedException"></exception>
//    private static void OnStartDownloadFileFunction(string fileName, long sizeBytes)
//    {
//        UnityEngine.Debug.LogWarning($"fileName = {fileName} sizeBytes = {sizeBytes}");
//    }

//    /// <summary>
//    /// �������
//    /// </summary>
//    /// <param name="isSucceed"></param>
//    /// <exception cref="NotImplementedException"></exception>
//    private static void OnDownloadOverFunction(bool isSucceed)
//    {
//        UnityEngine.Debug.LogWarning($"isSucceed = {isSucceed}");
//    }

//    /// <summary>
//    /// ������
//    /// </summary>
//    /// <param name="totalDownloadCount"></param>
//    /// <param name="currentDownloadCount"></param>
//    /// <param name="totalDownloadBytes"></param>
//    /// <param name="currentDownloadBytes"></param>
//    /// <exception cref="NotImplementedException"></exception>
//    private static void OnDownloadProgressUpdateFunction(int totalDownloadCount, int currentDownloadCount, long totalDownloadBytes, long currentDownloadBytes)
//    {
//        UnityEngine.Debug.LogWarning("������");
//    }

//    /// <summary>
//    /// ����ʧ��
//    /// </summary>
//    /// <param name="fileName"></param>
//    /// <param name="error"></param>
//    /// <exception cref="NotImplementedException"></exception>
//    private static void OnDownloadErrorFunction(string fileName, string error)
//    {
//        UnityEngine.Debug.LogWarning("����ʧ��");
//    }
//}

//public class QueryStreamingAssetsFileServices : IQueryServices
//{
//    public bool QueryStreamingAssets(string fileName)
//    {
//        // ע�⣺ʹ����BetterStreamingAssets�����ʹ��ǰ��Ҫ��ʼ���ò����
//        string buildinFolderName = YooAssets.GetStreamingAssetBuildinFolderName();
//        return false;
//    }
//}
