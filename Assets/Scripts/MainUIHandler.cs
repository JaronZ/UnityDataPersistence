using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        if (DataPersistence.Instance != null)
        {
            bestScoreText.text = "Best Score : " + DataPersistence.Instance.PlayerName + " : 0";
        }
    }
}
