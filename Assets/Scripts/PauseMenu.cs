using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            destroyAll();
        }
        
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
    void destroyAll()
    {
        Destroy(Menu);
       
        Destroy(gameObject);
    }
}
