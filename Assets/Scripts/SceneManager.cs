using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    private static readonly object padlock = new object();
    public static SceneManager instance;
    
    private void Awake()
    {
        lock (padlock)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        
        // 加载Loading场景
        AsyncOperation loadingOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Loading");
        while (!loadingOperation.isDone)
        {
            yield return null;
        }

        // 开始加载目标场景
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            // 通知LoadingUI更新进度
            LoadingUI.instance.UpdateProgress(operation.progress);
            yield return null;
        }
        LoadingUI.instance.UpdateProgress(1f); // 确保进度条填满

        // 等待一小段时间，确保UI显示完整
        yield return new WaitForSeconds(0.5f);
        
        if(LoadingUI.instance.CanLoad)
        {
            // 加载完毕，切换场景
            operation.allowSceneActivation = true;
        /*     operation = null;
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Loading"); */
        }
    }
}
