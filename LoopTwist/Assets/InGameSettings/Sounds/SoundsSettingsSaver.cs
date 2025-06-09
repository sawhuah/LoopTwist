using UnityEngine;
using UnityEngine.UI;

public class SoundsSettingsSaver : MonoBehaviour
{
    [SerializeField] private SoundsSettings _soundsSettings;
    [SerializeField] private Slider[] _sliders = new Slider[4]; 

    private void OnEnable()
    {
        _soundsSettings.SoundsSwitched.AddListener(OnSoundsSwitched);
    }

    private void OnSoundsSwitched(bool playSounds)
    {
        PlayerPrefs.SetInt("PlaySounds", playSounds ? 1 : 0);
    }

    public void SaveSliderValue(int sliderIndex)
    {
        PlayerPrefs.SetFloat(_soundsSettings.SlidersNames[sliderIndex], _sliders[sliderIndex].value);
    }
}
