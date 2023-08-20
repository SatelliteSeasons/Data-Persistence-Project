using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
// Les Classes dérivant de : MonoBehaviour, sont des composant scriptes d'attachement d'objet propre à Unity, et ne peuvent donc pas être instancié par un "new" sans qu'on l'attache quelque part,
// mais doit être par un "MyScript script = obj.AddComponent<MyScript>();" ; 
// Ainsi, MonoBehaviour surprimé ici car inutile
public class PlayerData
{
    public string playerName;
    public int playerScore;

    public PlayerData()
    {

    }

    public PlayerData(int playerScore)
    {
        this.playerScore = playerScore;
    }

    public PlayerData(string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }



    // get/set playerName
    public void SetName(string name)
    {
        this.playerName = name;
    }
    public string GetName()
    {
        return this.playerName;
    }

    // get/set playerScore
    public void SetBestScore(int score)
    {
        this.playerScore = score;
    }

    public int GetBestScore()
    {
        return this.playerScore;
    }

}
