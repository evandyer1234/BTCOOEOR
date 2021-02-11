using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Surprise : MonoBehaviour
{
    public float time = 1;
    public float Movespeed = 100;
    public int direction = 1;
    public GameObject darkness;
    public GameObject text;
    public GameObject perish;
    public GameObject victory;
    public GameObject chant;
    float startTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        startTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= startTime - 2f)
        {
            perish.SetActive(true);
        }
        if (time <= 3.5)
        {
            
            gameObject.transform.position += new Vector3(0, 0, Movespeed * direction) * Time.deltaTime;
        }
        if (time <= 2)
        {
            darkness.SetActive(true);
            victory.SetActive(true);
            chant.SetActive(false);
        }
        if (time <= 0)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
