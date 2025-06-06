using TMPro;
using UnityEngine;

public class BestScoreLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;

    private void Start()
    {
        _bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
