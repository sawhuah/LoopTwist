using UnityEngine;
using UnityEngine.UI;

public class SoundsSettingsView : MonoBehaviour
{
    [SerializeField] private SoundsSettings _soundsSettings;

    [Space(5)]
    [SerializeField] private Image _turnOffSoundsImage;
    [SerializeField] private Image _turnOnSoundsImage;

    [Space(5)]
    [SerializeField] private Color _turnedOffButtonColor;
    [SerializeField] private Color _turnedOnButtonColor;

    private void OnEnable()
    {
        _soundsSettings.SoundsSwitched.AddListener(OnSoundsSwitched);
    }

    private void OnSoundsSwitched(bool playSounds)
    {
        if(playSounds)
        {
            _turnOffSoundsImage.color = _turnedOffButtonColor;
            _turnOnSoundsImage.color = _turnedOnButtonColor;
        }
        else
        {
            _turnOffSoundsImage.color = _turnedOnButtonColor;
            _turnOnSoundsImage.color = _turnedOffButtonColor;
        }
    }
}
