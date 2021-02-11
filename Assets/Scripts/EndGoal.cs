using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGoal : MonoBehaviour
{
    int scenesIn;
    public int MaxScore = 10;
    int player1Score = 0;
    int player2Score = 0;
    int player3Score = 0;
    int player4Score = 0;
    public GameObject Menu;
    public TextMeshProUGUI Player1;
    public TextMeshProUGUI Player2;
    public TextMeshProUGUI Player3;
    public TextMeshProUGUI Player4;
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;
    public float Count;
    public bool isPaused = false;
    
    void Start()
    {
        Menu.SetActive(false);
        scenesIn = SceneManager.sceneCountInBuildSettings - 1;
        Player1.text = "Player 1: 0";
        Player2.text = "Player 2: 0";
        Player3.text = "Player 3: 0";
        Player4.text = "Player 4: 0";
    }

    
    void Update()
    {
        if (Input.GetButtonDown("MMp") || Input.GetKeyDown(KeyCode.Return))
        {
            if (isPaused)
            {
                Resume();
                isPaused = false;
            }
            else
            {
                Pause();
                isPaused = true;
            }
        }
        if (player1Score > MaxScore)
        {
            destroyAll();
            SceneManager.LoadScene(1);
            ScoreReset();

        }
        else if (player2Score > MaxScore)
        {
            destroyAll();
            SceneManager.LoadScene(2);
            ScoreReset();
        }
        else if (player3Score > MaxScore)
        {
            destroyAll();
            SceneManager.LoadScene(3);
            ScoreReset();
        }
        else if (player4Score > MaxScore)
        {
            destroyAll();
            SceneManager.LoadScene(4);
            ScoreReset();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "player1" || other.transform.parent.tag == "player2" || other.transform.parent.tag == "player3" || other.transform.parent.tag == "player4")
        {
            if (other.transform.parent.tag == "player1")
            {
                SetCountText1();
            }
            else if (other.transform.parent.tag == "player2")
            {
                SetCountText2();
            }
            else if (other.transform.parent.tag == "player3")
            {
                SetCountText3();
            }
            else if (other.transform.parent.tag == "player4")
            {
                SetCountText4();
            }
            SceneChange();
        }
        if (other.transform.tag == "PEnd")
        {
            Destroy(other.gameObject);
        }
    }
    public void SceneChange()
    {
        
        if (SceneManager.GetActiveScene().buildIndex <= scenesIn - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(18);
        }
    }
    public void SetCountText1()
    {
        
        player1Score += 1;
        
        Player1.text = "Player 1: " + player1Score;
    }
    public void SetCountText2()
    {
        player2Score += 1;
        Player2.text = "Player 2: " + player2Score;
    }
    public void SetCountText3()
    {
        player3Score += 1;
        Player3.text = "Player 3: " + player3Score;
    }
    public void SetCountText4()
    {
        player4Score += 1;
        Player4.text = "Player 4: " + player4Score;
    }
    void destroyAll()
    {
        Destroy(Menu);
        Destroy(square1);
        Destroy(square2);
        Destroy(square3);
        Destroy(square4);
        Destroy(gameObject);
    }
    void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Back()
    {
        Time.timeScale = 1f;
        destroyAll();
        SceneManager.LoadScene(0);
    }
    public void ScoreReset()
    {
        player1Score = 0;
        player2Score = 0;
        player3Score = 0;
        player4Score = 0;
    }
}
