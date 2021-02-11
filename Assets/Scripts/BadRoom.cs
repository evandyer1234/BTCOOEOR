using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadRoom : MonoBehaviour
{
    bool player1In = false;
    bool player2In = false;
    bool player3In = false;
    bool player4In = false;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1In && player2In && player3In && player4In)
        {
            SceneManager.LoadScene(6);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "player1")
        {
            player1In = true;
            p1.SetActive(true);
        }
        if (collision.transform.tag == "player2")
        {
            player2In = true;
            p1.SetActive(true);
        }
        if (collision.transform.tag == "player3")
        {
            player3In = true;
            p1.SetActive(true);
        }
        if (collision.transform.tag == "player4")
        {
            player4In = true;
            p1.SetActive(true);
        }
    }
}
