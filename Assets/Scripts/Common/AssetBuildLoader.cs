using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBuildLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { IEnumerator Start()
    {
        string url = "http://yourserver.com/AssetBundles/yourbundle";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject prefab = bundle.LoadAsset<GameObject>("YourPrefabName");
        Instantiate(prefab);
    }
    }
}
