using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex > 6)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
