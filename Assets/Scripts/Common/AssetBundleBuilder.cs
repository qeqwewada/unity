#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class AssetBundleBuilder
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (System.IO.Directory.Exists(assetBundleDirectory))
        {
            System.IO.Directory.Delete(assetBundleDirectory, true);
        }
        System.IO.Directory.CreateDirectory(assetBundleDirectory);

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
#endif
