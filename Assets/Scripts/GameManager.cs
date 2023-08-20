using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static SaveData saveData;

    public string namePlayer;
    public int actualScore;

    public string bestPlayer;
    public int bestScore;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            saveData = new SaveData();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        this.namePlayer = name;
    }

    public string GetName()
    {
        return this.namePlayer;
    }

    public void Save()
    {

        saveData.LoadDataJSON();
        if (saveData.dataPlayer.GetBestScore() <= actualScore)
        {
            saveData.dataPlayer.SetName(namePlayer);
            saveData.dataPlayer.SetBestScore(actualScore);
            saveData.SaveDataJSON();
        }
        else
        {
            Debug.Log("Impossible de sauver, trop faible score");
        }
    }

}
