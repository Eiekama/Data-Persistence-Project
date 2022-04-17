using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Username;
    public Dictionary<string, int> BestScores = new Dictionary<string, int>();

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

    public void SortScores()
    {
        var sortedScores = from score in BestScores
                           orderby score.Value descending
                           select score;
        BestScores = new Dictionary<string, int>();
        foreach (var pair in sortedScores)
        {
            BestScores.Add(pair.Key, pair.Value);
        }
        while (BestScores.Count > 5)
        {
            BestScores.Remove(BestScores.ElementAt(BestScores.Count - 1).Key);
        }
    }

    public void PrintScores()
    {
        foreach (var pair in BestScores)
        {
            Debug.Log(pair.Key + " : " + pair.Value);
        }
    }

    [System.Serializable]
    class DataToSave
    {
        public List<string> users = new List<string>();
        public List<int> scores = new List<int>();
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        foreach (var pair in BestScores)
        {
            data.users.Add(pair.Key);
            data.scores.Add(pair.Value);
        }

        string json = JsonUtility.ToJson(data);
        //Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);
            for (int i = 0; i < data.users.Count; i++)
            {
                Instance.BestScores.Add(data.users[i], data.scores[i]);
            }
        }
    }
}
