using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public InputField enterNameInput;
    public string playerName;

    void Start()
    {
        PlayerData playerData = new PlayerData();
        playerData = SaveData.instance.LoadScore();
        if(playerData != null)
        {
            bestScoreText.text = "Best Player : " + playerData.GetName() + " : " + playerData.GetBestScore();
        }
        else
        {
            Debug.Log("Aucun fichier, ou aucun meilleur joueur");
            bestScoreText.text = "Best Score : Nobody";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SetName(string name)
    {
        this.playerName = name;
        GameManager.instance.SetName(playerName);
    }

    public void DestroySave()
    {
        SaveData.instance.DestroySave();
    }

}
