using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI[] errors;

    private void Start()
    {
        if (DataManager.Instance.BestScores.Count == 0)
        {
            DataManager.Instance.LoadData();
        }
        DataManager.Instance.PrintScores();
        if (DataManager.Instance.BestScores.Count != 0)
        {
            bestScoreText.text = $"Congratulations to {DataManager.Instance.BestScores.ElementAt(0).Key} for best score of {DataManager.Instance.BestScores.ElementAt(0).Value}";
        }
        if (DataManager.Instance.Username != null)
        {
            input.text = DataManager.Instance.Username;
        }
    }

    bool IsNameValid()
    {
        if (input.text.Length == 0)
        {
            errors[0].enabled = true;
            return false;
        }
        else
        {
            return true;
        }
    }

    void StoreName()
    {
        DataManager.Instance.Username = input.text;
    }

    public void StartGame()
    {
        if (IsNameValid())
        {
            StoreName();
            SceneManager.LoadScene(1);
        }
    }

    public void SeeHighScores()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        DataManager.Instance.SaveData();
    }
}
