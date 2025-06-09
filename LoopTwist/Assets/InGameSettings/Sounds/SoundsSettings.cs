using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SoundsSettings : MonoBehaviour
{
    public UnityEvent<bool> SoundsSwitched;
    public string[] SlidersNames { get; private set; } = new string[] { "Click", "ButtonClick", "Bonus", "Death" };

    [Header("0 - Click, 1 - ButtonClick, 2 - Bonus, 3 - Death")]
    [SerializeField] private Slider[] _sliders = new Slider[4];

    private bool _playSounds = true;

    public void SwitchSounds(bool playSounds)
    {
        _playSounds = playSounds;

        for(int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].interactable = playSounds;
        }

        SoundsSwitched?.Invoke(playSounds);
    }
}
