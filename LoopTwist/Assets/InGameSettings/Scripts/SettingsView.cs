using UnityEngine;

public class SettingsView : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [Space(5)]
    [SerializeField] private Animator _settingsPanelAnimator;
    [SerializeField] private Animator _settingsButtonAnimator;

    private void Awake()
    {
        _settings.Opened.AddListener(OnSettingsOpened);
        _settings.Closed.AddListener(OnSettingsClosed);

        _settingsPanelAnimator.gameObject.SetActive(true);
    }

    private void OnSettingsOpened()
    {
        _settingsPanelAnimator.SetBool("IsAssigned", true);
        _settingsButtonAnimator.SetBool("IsAssigned", true);
    }

    private void OnSettingsClosed()
    {
        _settingsPanelAnimator.SetBool("IsAssigned", false);
        _settingsButtonAnimator.SetBool("IsAssigned", false);
    }
}
