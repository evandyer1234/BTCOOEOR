using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    public bool clone = false;
    public Bashed basher;
    public float timer;
    public GameObject Shooter;
    public GameObject SpawnLocation;
    public float RotationRate = 100f;

    // Start is called before the first frame update
    void Start()
    {
        if (clone)
        {
            Shooter.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clone)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
                Shooter.SetActive(true);
            }
            Bashed clone = (Bashed)Instantiate(basher, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
            clone.clone = true;
            gameObject.transform.Rotate(RotationRate * Time.fixedDeltaTime * Vector3.up);
        }
    }
}
