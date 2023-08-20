using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData : MonoBehaviour
{
    public DataPlayer dataPlayer = new DataPlayer();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveDataJSON()
    {
        string bestPlayer = JsonUtility.ToJson(dataPlayer);
        string filePath = Application.persistentDataPath + "/bestPlayer.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, bestPlayer);
        Debug.Log("Charger");
    }

    public void LoadDataJSON()
    {
        string filePath = Application.persistentDataPath + "/bestPlayer.json";
        string bestPlayer = System.IO.File.ReadAllText(filePath);


        dataPlayer = JsonUtility.FromJson<DataPlayer>(bestPlayer);



    }

    public void PeekDataJSON()
    {

    }

}

[Serializable]
public class DataPlayer
{
    public string playerName;
    public int bestScore;

    public void SetName(string name)
    {
        this.playerName = name;
    }

    public string GetName()
    {
        return this.playerName;
    }

    public void SetBestScore(int score)
    {
        this.bestScore = score; 
    }

    public int GetBestScore()
    {
        return this.bestScore;
    }
}
