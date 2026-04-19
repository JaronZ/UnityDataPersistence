using System;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance { get; private set; }

    public string PlayerName;

    public string BestPlayerName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveBestScore()
    {
        SaveData data = new()
        {
            bestPlayerName = BestPlayerName,
            bestScore = BestScore
        };

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = data.bestPlayerName;
            BestScore = data.bestScore;
        }
    }
    
    [Serializable]
    internal struct SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }
}
