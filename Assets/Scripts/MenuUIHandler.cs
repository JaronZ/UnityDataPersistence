using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void PlayerNameInput(String playerName)
    {
        DataPersistence.Instance.PlayerName = playerName;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
