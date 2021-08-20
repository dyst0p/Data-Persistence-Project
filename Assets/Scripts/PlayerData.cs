using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public string PlayerName { get; set; }
    public static PlayerData Instance;
    public string bestPlayer;
    public int bestScore;

    // Start is called before the first frame update
    void Awake()
    {
        // singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerName = "Player";
        LoadBestScore();
    }

    void LoadBestScore()
    {
        BestScoreData data;

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<BestScoreData>(json);
        }
        else
        {
            data = new BestScoreData();
        }

        bestPlayer = data.bestPlayer;
        bestScore = data.bestScore;
    }

    public void SaveBestScore()
    {
        BestScoreData data = new BestScoreData();
        data.bestScore = this.bestScore;
        data.bestPlayer = this.bestPlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    [Serializable]
    class BestScoreData
    {
        public int bestScore;
        public string bestPlayer;
    }
}
