using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public int Scene = 0;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(Scene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        
}
