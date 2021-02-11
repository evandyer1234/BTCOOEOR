using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    int RNum = 0;
   
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;

    // Start is called before the first frame update
    void Start()
    {

        
        Music();
    }

    // Update is called once per frame
    void Update()
    {
        RNum = Random.Range(1, 9);
    }
    public void Music()
    {
        AllOff();
       
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
    }
    void AllOff()
    {
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        cube5.SetActive(false);
        cube6.SetActive(false);
        cube7.SetActive(false);
        cube8.SetActive(false);
    }
}
