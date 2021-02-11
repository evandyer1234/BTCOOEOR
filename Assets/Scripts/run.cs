using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public GameObject leg1;
    public GameObject leg2;
    public GameObject foot1;
    public GameObject foot2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foot1.transform.position = leg1.transform.position;
        foot2.transform.position = leg2.transform.position;
    }
}
