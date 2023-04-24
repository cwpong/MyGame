using DG.Tweening.Plugins.Core.PathCore;
using System.IO;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using static UnityEditor.Progress;

public class ImageImporter: AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
    }

    private void OnPreprocessAsset()
    {
        var strSpinePath = "/Res/Spine/";

        // 因为spine文件打算都放这里 所以只检测这里的文件
        if (assetPath.Contains(strSpinePath))
        {
            if (assetPath.EndsWith(".atlas"))
            {
                var srt = System.IO.Path.ChangeExtension(assetPath, ".atlas.txt");
                File.Move(assetPath, srt);
                UnityEngine.Debug.Log($"成功导入Spine atlas文件 {srt}");
            }
            else if (assetPath.EndsWith(".skel"))
            {
                var srt = System.IO.Path.ChangeExtension(assetPath, ".skel.bytes");
                File.Move(assetPath, srt);
                UnityEngine.Debug.Log($"成功导入Spine skel文件 {srt}");
            }
        }
    }
}