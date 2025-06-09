using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundsSettingsLoader : MonoBehaviour
{
    [SerializeField] private SoundsSettings _soundsSettings;

    [Space(5)]
    [SerializeField] private Slider[] _sliders = new Slider[4];
    [SerializeField] private AudioSource[] _soundsAudioSources = new AudioSource[4];

    private void Awake()
    {
        _soundsSettings.SoundsSwitched.AddListener(OnSoundsSwitched);

        Load();

        for(int i = 0; i < _soundsAudioSources.Length; i++)
        {
            SetSoundValue(i);
        }
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("PlaySounds"))
            _soundsSettings.SwitchSounds(Convert.ToBoolean(PlayerPrefs.GetInt("PlaySounds")));
        else
            _soundsSettings.SwitchSounds(true);

        for (int i = 0; i < _soundsSettings.SlidersNames.Length; i++)
        {
            if (PlayerPrefs.HasKey(_soundsSettings.SlidersNames[i]))
            {
                _sliders[i].value = PlayerPrefs.GetFloat(_soundsSettings.SlidersNames[i]);
            }
            else
            {
                _sliders[i].value = 0.5f;
            }
        }
    }

    public void SetSoundValue(int sliderIndex)
    {
        if (_soundsAudioSources[sliderIndex] != null)
            _soundsAudioSources[sliderIndex].volume = _sliders[sliderIndex].value;
    }

    private void OnSoundsSwitched(bool value)
    {
        for(int i = 0; i < _soundsAudioSources.Length; ++i)
        {
            if(_soundsAudioSources[i] != null)
                _soundsAudioSources[i].gameObject.SetActive(value);
        }
    }
}
