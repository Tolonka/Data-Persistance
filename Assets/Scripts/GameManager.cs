using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string highScoreName;
    public string playerName;
    public int highScore;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData dataToSave = new SaveData();
        dataToSave.highScore = highScore;
        dataToSave.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

            highScore = loadedData.highScore;
            highScoreName = loadedData.highScoreName;
        }
    }

}
