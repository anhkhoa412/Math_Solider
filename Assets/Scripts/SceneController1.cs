using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string scenePath;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeScene()
    {
        //SceneManager.LoadScene("SampleScene"); // Truyền vào tên scene
        //SceneManager.LoadScene(0); Truyền vào buildIndex
        SceneManager.LoadScene(scenePath);
    }
    public void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.name + "--" + currentScene.buildIndex + "--" + currentScene.path);



        // Single

        SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Additive);
    }

    public void LoadScenAsync()
    {
        StartCoroutine(LoadSceneAsyncCoroutine());
    }
    IEnumerator LoadSceneAsyncCoroutine()
    {
        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            Debug.Log(progress);
            yield return null;
        }

        Debug.Log("Scene Loaded");
    }
}
