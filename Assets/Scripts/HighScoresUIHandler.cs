using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class HighScoresUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI listingsText;

    private void Start()
    {
        UpdateRankings();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateRankings()
    {
        listingsText.text = "";
        for (int i = 0; i < 5; i++)
        {
            listingsText.text += $"{i + 1}: {DataManager.Instance.BestScores.ElementAt(i).Key} : {DataManager.Instance.BestScores.ElementAt(i).Value}\n";
        }
    }
}
