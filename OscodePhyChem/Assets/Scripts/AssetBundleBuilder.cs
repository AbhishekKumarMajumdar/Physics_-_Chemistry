#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class AssetBundleBuilder
{
    [MenuItem("Assets/Build Asset Bundles")]
    public static void BuildAllAssetBundles()
    {
        string outputPath = "Assets/AssetBundles";
        if (!System.IO.Directory.Exists(outputPath))
            System.IO.Directory.CreateDirectory(outputPath);

        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        Debug.Log("Asset Bundles built successfully.");
    }
}
#endif