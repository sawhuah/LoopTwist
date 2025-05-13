using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    public UnityEvent LoadingStarted;
    public AsyncOperation LoadingOperation { get; private set; }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
        LoadingStarted?.Invoke();
    }

    private IEnumerator LoadSceneAsync(int index)
    {
        LoadingOperation = SceneManager.LoadSceneAsync(index);
        LoadingOperation.allowSceneActivation = false;

        while(!LoadingOperation.isDone)
        {
            if(LoadingOperation.progress >= 0.9f && !LoadingOperation.allowSceneActivation)
            {
                LoadingOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
