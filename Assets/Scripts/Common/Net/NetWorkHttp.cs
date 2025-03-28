using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class NetWorkHttp : MonoBehaviour
{
    private static NetWorkHttp instance;
    private float timeout = 10f; // 默认超时时间10秒
    
    public static NetWorkHttp Instance
    {
        get
        {
            if (instance == null)
            {
                var go = new GameObject("NetWorkHttp");
                instance = go.AddComponent<NetWorkHttp>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void Get(string url, Action<string> onSuccess = null, Action<string> onError = null, Dictionary<string, string> headers = null)
    {
        StartCoroutine(GetRequest(url, onSuccess, onError, headers));
    }

    public void Post(string url, string jsonData, Action<string> onSuccess = null, Action<string> onError = null, Dictionary<string, string> headers = null)
    {
        StartCoroutine(PostRequest(url, jsonData, onSuccess, onError, headers));
    }

    private IEnumerator GetRequest(string url, Action<string> onSuccess, Action<string> onError, Dictionary<string, string> headers)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // 设置超时
            webRequest.timeout = Mathf.RoundToInt(timeout);

            // 添加请求头
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || 
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError?.Invoke(webRequest.error);
                Debug.LogError($"请求错误: {url} - {webRequest.error}");
            }
            else
            {
                onSuccess?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    private IEnumerator PostRequest(string url, string jsonData, Action<string> onSuccess, Action<string> onError, Dictionary<string, string> headers)
    {
        using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // 设置超时
            webRequest.timeout = Mathf.RoundToInt(timeout);

            // 添加自定义请求头
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || 
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError?.Invoke(webRequest.error);
                Debug.LogWarning($"请求错误: {url} - {webRequest.error}");
            }
            else
            {
                onSuccess?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    public void SetTimeout(float seconds)
    {
        timeout = Mathf.Max(1f, seconds); // 确保超时时间至少为1秒
    }
}
