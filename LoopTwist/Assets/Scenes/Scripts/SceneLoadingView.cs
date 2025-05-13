using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingView : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private Image _progressFiller;

    private bool _isAnySceneLoading = false;

    private void Start()
    {
        _loadingScreen.SetActive(false);
        _sceneLoader.LoadingStarted.AddListener(OnLoadingStarted);
    }

    private void Update()
    {
        if(_isAnySceneLoading)
        {
            _progressFiller.fillAmount = _sceneLoader.LoadingOperation.progress;
        }
    }

    private void OnLoadingStarted()
    {
        _loadingScreen.SetActive(true);
        _isAnySceneLoading = true;
    }
}
