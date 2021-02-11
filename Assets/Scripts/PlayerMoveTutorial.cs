using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTutorial : MonoBehaviour
{
    public int isPlayer = 0;
    public Transform direction;
    public GameObject bottom;
    public GameObject leg1;
    public GameObject leg2;
    public GameObject foot1;
    public GameObject foot2;
    public GameObject jumpfeet;
    public GameObject fallfeet;
    public GameObject idlefeet;
    float spinRate = 700f;
   
    public List<GameObject> SpawnList;
    int SpawnListIndex;

    bool forward = false;
    bool backward = false;
    bool left = false;
    bool right = false;
    bool spinl = false;
    bool spinr = false;
    bool punch = false;
    bool jump = false;
    bool jumpset = false;
    bool doubleJump = true;
    bool explode = false;
    bool shoot = false;
    bool kexplode = false;
   
    bool kshoot = false;
   
    bool kjump = false;
    bool kpunch = false;
    float pforward = 0;
    float pright = 0;
    

    float boostRate = 500;
    public float resetTime = 1;
    float currentTime = 0;

    public GameObject SpawnLocation;
    float jumpHieght = 600;

    bool canDash = false;
    bool jumping = false;
    bool falling = false;

    public DoubleJump cloud;
    public Punch projectile;
    public GameObject particle;
    public GameObject resetPoint;
    public Explosive boom;
    public RNG bullet;
    public Rigidbody blast;

    float RotationRate = 200;
    float MoveRate = 10;
    bool dashing = false;
    Transform transf;
    Rigidbody rb;

    bool check1 = true;
    bool check2 = true;

    void Start()
    {
        currentTime = resetTime;
        rb = GetComponent<Rigidbody>();
        resetPoint = SpawnList[SpawnListIndex];
        foot1.transform.position = leg1.transform.position;
        foot2.transform.position = leg2.transform.position;
        jumpfeet.SetActive(false);
        fallfeet.SetActive(false);
        particle.SetActive(false);
        idlefeet.SetActive(false);
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (rb.velocity.y > 0.1)
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }
        if (rb.velocity.y < -0.1)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
        if (jumping)
        {
            foot1.SetActive(false);
            foot2.SetActive(false);
            jumpfeet.SetActive(true);
            fallfeet.SetActive(false);
            idlefeet.SetActive(false);
        }
        if (falling)
        {
            foot1.SetActive(false);
            foot2.SetActive(false);
            jumpfeet.SetActive(false);
            fallfeet.SetActive(true);
            idlefeet.SetActive(false);
        }
        if (jumping == false && falling == false)
        {
            foot1.SetActive(true);
            foot2.SetActive(true);
            jumpfeet.SetActive(false);
            fallfeet.SetActive(false);
            idlefeet.SetActive(false);
        }
        if (dashing)
        {
            foot1.SetActive(false);
            foot2.SetActive(false);
            jumpfeet.SetActive(true);
            fallfeet.SetActive(false);
            idlefeet.SetActive(false);
        }
        if (dashing == false && falling == false && jumping == false && pforward == 0 && forward == false && backward == false)
        {
            foot1.SetActive(false);
            foot2.SetActive(false);
            jumpfeet.SetActive(false);
            fallfeet.SetActive(false);
            idlefeet.SetActive(true);
        }
        resetPoint = SpawnList[SpawnListIndex];
    }

    private void FixedUpdate()
    {

        player1();


        if (forward)
        {
            MoveForward(1);
        }

        if (backward)
        {
            MoveForward(-1);
        }
        if (pforward != 0)
        {
            MoveForward(-pforward);
        }
        if (pright != 0)
        {
            Rotate(pright);
        }

        if (left)
        {
            Rotate(-1);
        }

        if (right)
        {
            Rotate(1);
        }

        if (spinr)
        {
            Rotate(1);
        }
        if (spinl)
        {
            Rotate(-1);
        }
        if (punch || kpunch)
        {
            Punch();
        }
        if (jump || kjump)
        {
            if (jumpset)
            {
                rb.AddForce(transform.up * jumpHieght);
                jumpset = false;
            }
            else if (doubleJump)
            {

                particle.SetActive(false);
                dashing = false;
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(transform.up * jumpHieght);
                doubleJump = false;
                DoubleJump clone = (DoubleJump)Instantiate(cloud, gameObject.transform.position, gameObject.transform.rotation);
                clone.Clone = true;
            }
        }
        if (explode || kexplode)
        {
            SelfDestruct();
        }
        if (shoot || kshoot)
        {
            if (currentTime < 0)
            {
                Boost();
                currentTime = resetTime;
            }
        }

    }
    
    public void MoveForward(float value)
    {
        Vector3 location = rb.position;

        location += (value * MoveRate * Time.fixedDeltaTime * transform.forward);


        rb.position = location;
        bottom.transform.Rotate(value * spinRate * Time.fixedDeltaTime * Vector3.right);
        foot1.transform.position = leg1.transform.position;
        foot2.transform.position = leg2.transform.position;
    }
    public void Rotate(float value)
    {
        gameObject.transform.Rotate(value * RotationRate * Time.fixedDeltaTime * Vector3.up);
    }


    public void Punch()
    {
        Punch clone = (Punch)Instantiate(projectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        clone.clone = true;
        if (isPlayer == 1)
        {
            clone.isPlayer1 = true;
        }
        if (isPlayer == 2)
        {
            clone.isPlayer2 = true;
        }
        if (isPlayer == 3)
        {
            clone.isPlayer3 = true;
        }
        if (isPlayer == 4)
        {
            clone.isPlayer4 = true;
        }
    }
    public void SelfDestruct()
    {
        Explosive clone = (Explosive)Instantiate(boom, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        clone.clone = true;
        Reset();
    }
    public void Blaster()
    {
        RNG clone = (RNG)Instantiate(bullet, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        clone.clone = true;
    }
    public void Boost()
    {
        if (canDash)
        {
            rb.AddForce(transform.forward * boostRate);
            canDash = false;
            particle.SetActive(true);
            dashing = true;
        }
    }
    public void player1()
    {
        if (isPlayer == 1)
        {
            forward = Input.GetKey(KeyCode.W);
            backward = Input.GetKey(KeyCode.S);
            left = Input.GetKey(KeyCode.A);
            right = Input.GetKey(KeyCode.D);
            kpunch = Input.GetKeyDown(KeyCode.E);
            kjump = Input.GetKeyDown(KeyCode.Space);
            kexplode = Input.GetKeyDown(KeyCode.X);
            kshoot = Input.GetKeyDown(KeyCode.Q);

            
            pforward = Input.GetAxis("1LeftJoystickY");
            pright = Input.GetAxis("1LeftJoystickX");
            punch = Input.GetButtonDown("1X");
            jump = Input.GetButtonDown("1A");
            explode = Input.GetButtonDown("1Y");
            shoot = Input.GetButtonDown("1B");
            
           
        }
    }
   
    void OnCollisionEnter(Collision collision)
    {

        jumpset = true;
        doubleJump = true;
        canDash = false;
        particle.SetActive(false);
        dashing = false;

        if (collision.transform.tag == "KillZone" || collision.transform.tag == "Goal")
        {
            Reset();
        }
    }
    void OnCollisionExit(Collision collision)
    {
        jumpset = false;
        canDash = true;
    }
    void Reset()
    {
        particle.SetActive(false);
        rb.velocity = new Vector3(0, 0, 0);
        this.transform.position = resetPoint.transform.position;
        this.transform.rotation = resetPoint.transform.rotation;
    }
    void OtherReset()
    {

        this.transform.position = resetPoint.transform.position;
        this.transform.rotation = resetPoint.transform.rotation;
    }
    void Awake()
    {
        OtherReset();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Checkpoint1")
        {
            if (check1)
            {
                SpawnListIndex++;
                check1 = false;
            }
        }
        if (collision.transform.tag == "Checkpoint2")
        {
            if (check2)
            {
                SpawnListIndex++;
                check1 = false;
            }
        }
    }
}
