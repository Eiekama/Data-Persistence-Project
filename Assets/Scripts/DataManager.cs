using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Username;
    public string BestUser;
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

    class DataToSave
    {
        public string bestUser;
        public int bestScore;
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave
        {
            bestUser = BestUser,
            bestScore = BestScore
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);
            Instance.BestUser = data.bestUser;
            Instance.BestScore = data.bestScore;
        }
    }
}
