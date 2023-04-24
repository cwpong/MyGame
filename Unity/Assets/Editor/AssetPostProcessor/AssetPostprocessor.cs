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

        // ��Ϊspine�ļ����㶼������ ����ֻ���������ļ�
        if (assetPath.Contains(strSpinePath))
        {
            if (assetPath.EndsWith(".atlas"))
            {
                var srt = System.IO.Path.ChangeExtension(assetPath, ".atlas.txt");
                File.Move(assetPath, srt);
                UnityEngine.Debug.Log($"�ɹ�����Spine atlas�ļ� {srt}");
            }
            else if (assetPath.EndsWith(".skel"))
            {
                var srt = System.IO.Path.ChangeExtension(assetPath, ".skel.bytes");
                File.Move(assetPath, srt);
                UnityEngine.Debug.Log($"�ɹ�����Spine skel�ļ� {srt}");
            }
        }
    }
}