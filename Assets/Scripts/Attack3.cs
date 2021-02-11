using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3 : MonoBehaviour
{
    public bool clone = false;
    public float RotationRate = 100f;
    public float lifeTime = 2f;
    public GameObject arm;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public int rPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (clone)
        {
            arm.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(rPlayer);
        if (clone)
        {
            lifeTime -= Time.deltaTime;
            gameObject.transform.Rotate(RotationRate * Time.fixedDeltaTime * Vector3.up);
        }
        if (lifeTime <= 0)
        {
            arm.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
