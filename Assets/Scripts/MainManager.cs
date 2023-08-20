using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    //UI
    public TextMeshProUGUI NameText;
    public Text ScoreText;
    public GameObject GameOverText;
    public Text BestScoreText;
    
    private bool m_Started = false;
    private int m_Points; //score point
    
    private bool m_GameOver = false;

    private PlayerData bestPlayer;


    void Start()
    {
        this.LoadBestPlayer();
        this.m_Points = 0;
        NameText.text = GameManager.instance.GetName();

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(this.bestPlayer.GetBestScore() < this.m_Points)
        {
            this.BestScoreText.text = "Best Score : " + this.NameText.text + " : " + this.m_Points;
            this.bestPlayer.SetBestScore(m_Points);
            this.bestPlayer.SetName(this.NameText.text);
            SaveData.instance.SaveScore(this.bestPlayer);
        }

    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadBestPlayer()
    {
        bestPlayer = SaveData.instance.LoadScore();
        if(bestPlayer == null)
        {
            BestScoreText.text = "Best Score : Nobody";
            bestPlayer = new PlayerData(0);
        }
        else
        {
            BestScoreText.text = "Best Score : " + bestPlayer.GetName() + " : " + bestPlayer.GetBestScore();
        }
    }
}
