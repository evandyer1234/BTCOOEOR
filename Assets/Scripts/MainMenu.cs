using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    EventSystem m_EventSystem;
    public GameObject Main;
    public GameObject musicMenu;
    public GameObject levelmenu;
    public GameObject credits;
    public GameObject plot;
    public GameObject controlMenu;
    public GameObject fbMusic;
    public GameObject fbLevel;
    public GameObject fbMain;
    public GameObject fbCredits;
    public GameObject fbPlot;
    public GameObject fbControls;
    
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;
    public GameObject cube9;
    public GameObject cube10;
    public GameObject cube11;
    public GameObject cube12;
    public GameObject cube13;
    public GameObject cube14;
    public GameObject cube15;
    public GameObject cube16;
    public GameObject cube17;
    public float Count = .5f;
   
    public void Start()
    {
        Main.SetActive(true);
        musicMenu.SetActive(false);
        levelmenu.SetActive(false);
        m_EventSystem = EventSystem.current;
        AllOff(1);

    }
    public void Begin()
    {
        StartCoroutine(Go());
       
        
    }
    IEnumerator Go()
    {
        yield return new WaitForSeconds(Count);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 17);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(5);
    }
    public void Music(int RNum)
    {
        AllOff(0);
        if (RNum == 1)
        {
            cube1.SetActive(true);
        }
        if (RNum == 2)
        {
            cube2.SetActive(true);
        }
        if (RNum == 3)
        {
            cube3.SetActive(true);
        }
        if (RNum == 4)
        {
            cube4.SetActive(true);
        }
        if (RNum == 5)
        {
            cube5.SetActive(true);
        }
        if (RNum == 6)
        {
            cube6.SetActive(true);
        }
        if (RNum == 7)
        {
            cube7.SetActive(true);
        }
        if (RNum == 8)
        {
            cube8.SetActive(true);
        }
        if (RNum == 9)
        {
            cube9.SetActive(true);
        }
        if (RNum == 10)
        {
            cube10.SetActive(true);
        }
        if (RNum == 11)
        {
            cube11.SetActive(true);
        }
        if (RNum == 12)
        {
            cube12.SetActive(true);
        }
        if (RNum == 13)
        {
            cube13.SetActive(true);
        }
        if (RNum == 14)
        {
            cube14.SetActive(true);
        }
        if (RNum == 15)
        {
            cube15.SetActive(true);
        }
        if (RNum == 16)
        {
            cube16.SetActive(true);
        }
        if (RNum == 17)
        {
            cube17.SetActive(true);
        }
    }
    public void AllOff(int num)
    {
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        cube5.SetActive(false);
        cube6.SetActive(false);
        cube7.SetActive(false);
        cube8.SetActive(false);
        cube9.SetActive(false);
        cube10.SetActive(false);
        if (num == 0)
        {
            cube11.SetActive(false);
        }
        cube12.SetActive(false);
        cube13.SetActive(false);
        cube14.SetActive(false);
        cube15.SetActive(false);
        cube16.SetActive(false);
        cube17.SetActive(false);
    }
    public void MainBack()
    {
        
        musicMenu.SetActive(false);
        levelmenu.SetActive(false);
        credits.SetActive(false);
        Main.SetActive(true);
        plot.SetActive(false);
        controlMenu.SetActive(false);
        m_EventSystem.SetSelectedGameObject(fbMain);
    }
    public void MusicMenu()
    {
        
        musicMenu.SetActive(true);
        Main.SetActive(false);
        m_EventSystem.SetSelectedGameObject(fbMusic);
    }
    public void LevelMenu()
    {
        
        Main.SetActive(false);
        levelmenu.SetActive(true);
        m_EventSystem.SetSelectedGameObject(fbLevel);
    }
    public void PlotMenu()
    {
        Main.SetActive(false);
        plot.SetActive(true);
        m_EventSystem.SetSelectedGameObject(fbPlot);
    }
    public void ControlMenu()
    {
        Main.SetActive(false);
        controlMenu.SetActive(true);
        m_EventSystem.SetSelectedGameObject(fbControls);
    }
    public void Level(int num)
    {
        SceneManager.LoadScene(num + 7);
    }
    public void Credits()
    {
        Main.SetActive(false);
        credits.SetActive(true);
        m_EventSystem.SetSelectedGameObject(fbCredits);
    }
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
