using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    Rigidbody rb;
    public GameObject target;
    public float MoveRate = 5f;
    bool end = false;
    void Update()
    {
        if (end == false)
        {
            Vector3 location = gameObject.transform.position;

            location += (MoveRate * Time.fixedDeltaTime * transform.up);


            gameObject.transform.position = location;
        }
        if (gameObject.transform.position.y >= target.transform.position.y)
        {
            end = true;
        }
    }
}