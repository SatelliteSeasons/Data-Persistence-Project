using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public InputField enterNameInput;
    public string enterName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

    }

    public void SetName(string name)
    {
        this.enterName = name;
        Debug.Log(name);
        GameManager.Instance.SetName(name);
    }
}
