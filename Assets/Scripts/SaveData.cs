using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveScore(PlayerData playerData)
    {
        string bestPlayer = JsonUtility.ToJson(playerData);
        string filePath = Application.persistentDataPath + "/bestPlayer.json";
        System.IO.File.WriteAllText(filePath, bestPlayer);
        Debug.Log(filePath);
    }

    public PlayerData LoadScore()
    {
        string filePath = Application.persistentDataPath + "/bestPlayer.json";
        if(File.Exists(filePath))
        {
            string bestPlayer = File.ReadAllText(filePath);
            PlayerData playerData = new PlayerData();
            playerData = JsonUtility.FromJson<PlayerData>(bestPlayer);
            return playerData;
        }
        else
        {
            return null;
        }
    }

    public void DestroySave()
    {
        string filePath = Application.persistentDataPath + "/bestPlayer.json";
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
            SceneManager.LoadScene(0);
            Debug.Log("fichier détruit");

        }
        else
        {
            Debug.Log("Fichier non existant");
        }
    }

}
