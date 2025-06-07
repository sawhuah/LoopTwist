using UnityEngine;
using UnityEngine.Events;

public class LanguageChanger : MonoBehaviour
{
    public UnityEvent<int> Changed;

    [Header("Languages")]
    [SerializeField] private EnglishLanguage _english;
    [SerializeField] private RussianLanguage _russian;
    [SerializeField] private GermanLanguage _german;

    private ILanguage _selectedLanguage;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Language"))
        {
            Change(PlayerPrefs.GetInt("Language"));
        }
        else
        {
            _selectedLanguage = _english;
        }
    }

    public void Change(int index)
    {
        _selectedLanguage = GetLanguageByIndex(index);
        PlayerPrefs.SetInt("Language", index);

        Changed?.Invoke(index);
    }

    private ILanguage GetLanguageByIndex(int index)
    {
        switch (index)
        {
            case 0:
                return _english;
            case 1:
                return _russian;
            case 2:
                return _german;
            default:
                return _english;
        }
    }
}
