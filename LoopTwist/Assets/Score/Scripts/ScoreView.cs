using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _label;

    private void Awake()
    {
        _scoreCounter.ScoreChanged.AddListener(OnScoreChanged);
    }

    private void OnScoreChanged(int amount)
    {
        _label.text = amount.ToString();
    }
}
