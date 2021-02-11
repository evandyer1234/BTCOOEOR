using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomApple : MonoBehaviour
{
    public float time;
    public bool isMain = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMain)
        { 
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}
