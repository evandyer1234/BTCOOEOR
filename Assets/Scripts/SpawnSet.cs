using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSet : MonoBehaviour
{
    public GameObject points;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "player1" || other.transform.parent.tag == "player2" || other.transform.parent.tag == "player3" || other.transform.parent.tag == "player4")
        {
            points.transform.position = target.transform.position;
            Destroy(gameObject);
        }
    }
}