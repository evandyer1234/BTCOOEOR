using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bob : MonoBehaviour
{
    public float bobDistance = 10f;
    public float bobSpeed = 50f;
    float startPoint = 0;
    bool isGoingUp = true;
    
    // Start is called before the first frame update
    void Start()
    {
        startPoint = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGoingUp == true)
        {
            if (gameObject.transform.position.y <= startPoint + bobDistance)
            {
                gameObject.transform.position += new Vector3(0, bobSpeed, 0);
            }
        }
        if (isGoingUp == false)
        {
            if (gameObject.transform.position.y >= startPoint - bobDistance)
            {
                gameObject.transform.position += new Vector3(0, -bobSpeed, 0);
            }
        }
        ChangeDirection();
    }
    void ChangeDirection()
    {
        if (isGoingUp && gameObject.transform.position.y >= startPoint + bobDistance)
        {
            isGoingUp = false;
        }
        if (isGoingUp == false && gameObject.transform.position.y <= startPoint - bobDistance)
        {
            isGoingUp = true;
        }
    }
    
}
