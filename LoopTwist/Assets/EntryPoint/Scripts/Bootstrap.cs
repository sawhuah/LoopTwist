using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 240;
        QualitySettings.vSyncCount = 0;
    }
}
