using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bashed : MonoBehaviour
{
    public bool clone = false;
    public float MoveRate = 100;
    public float lifetime = 1f;
    float currentTime = 0;
    Transform transf;
    public bool isLaser = false;
    public dissolve smaller;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (clone)
        {
            gameObject.transform.position += (Time.deltaTime * MoveRate * transform.forward);
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isLaser)
        {
            if (collision.transform.parent.tag == "player1" || collision.transform.parent.tag == "player2" || collision.transform.parent.tag == "player3" || collision.transform.parent.tag == "player4")
            {
                dissolve clone = (dissolve)Instantiate(smaller, gameObject.transform.position, gameObject.transform.rotation);
                clone.isClone = true;
            }
        }
    }
}
