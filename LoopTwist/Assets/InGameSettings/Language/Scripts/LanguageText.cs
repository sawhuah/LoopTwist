using TMPro;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
    [SerializeField] private LanguageChanger _languageChanger;
    [SerializeField] private TMP_Text _textToChange;

    [Space(5)]
    [Header("0 - English, 1 - Russian, 2 - German")]
    [SerializeField] private string[] _text;

    private int _languageIndex;

    private void OnEnable()
    {
        _languageChanger.Changed.AddListener(OnLanguageChanged);
    }

    private void OnLanguageChanged(int index)
    {
        _languageIndex = index;
        _textToChange.text = _text[index];
    }
}
