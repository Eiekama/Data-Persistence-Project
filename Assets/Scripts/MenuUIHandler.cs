using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
        DataManager.Instance.LoadData();
        if (DataManager.Instance.BestUser != "")
        {
            bestScoreText.text = $"Congratulations to {DataManager.Instance.BestUser} for best score of {DataManager.Instance.BestScore}";
        }
    }

    bool IsNameValid()
    {
        if (input.text.Length == 0)
        {
            errors[0].enabled = true;
            return false;
        } //add elif later to check if name is taken
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
