using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
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


    bool forward = false;
    bool backward = false;
    bool left = false;
    bool right = false;
    bool spinl = false;
    bool spinr = false;
    bool punch = false;
    bool kpunch = false;
    bool jump = false;
    bool kjump = false;
    bool jumpset = false;
    bool doubleJump = true;
    bool kexplode = false;
    bool explode = false;
    bool kshoot = false;
    bool shoot = false;
    float pforward = 0;
    float pright = 0;
    float CUp = 0;
    float CRight = 0;

    float boostRate = 500;
    public float resetTime = 1;
    float currentTime = 0;

    public GameObject SpawnLocation;
    float jumpHieght = 600;

    bool canDash = false;
    bool dashing = false;

    public DoubleJump cloud;
    public GameObject particle;
    public Punch projectile;
    public GameObject resetPoint;
    public Explosive boom;
    public RNG bullet;
    public Rigidbody blast;

    float RotationRate = 200;
    float spinRate = 700f;
    float MoveRate = 10;
    bool jumping = false;
    bool falling = false;

    Transform transf;
    Rigidbody rb;
    void Start()
    {
        currentTime = resetTime;
        rb = GetComponent<Rigidbody>();
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
        player1();
        player2();
        player3();
        player4();
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

            Boost();
            currentTime = resetTime;


        }
    }
        private void FixedUpdate()
    { 
        {

       

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
        
        }
        if (CRight != 0)
        {
            gameObject.transform.Rotate(CRight * RotationRate * Time.fixedDeltaTime * Vector3.up);
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
            kexplode = Input.GetKeyDown(KeyCode.R);
            kshoot = Input.GetKeyDown(KeyCode.Q);

            pforward = Input.GetAxis("1LeftJoystickY");
            pright = Input.GetAxis("1LeftJoystickX");
            punch = Input.GetButtonDown("1X");
            jump = Input.GetButtonDown("1A");
            explode = Input.GetButtonDown("1Y");
            shoot = Input.GetButtonDown("1B");


        }
    }
    public void player2()
    {
        if (isPlayer == 2)
        {
            
                forward = Input.GetKey(KeyCode.I);
                backward = Input.GetKey(KeyCode.K);
                left = Input.GetKey(KeyCode.J);
                right = Input.GetKey(KeyCode.L);
                kpunch = Input.GetKeyDown(KeyCode.U);
                kjump = Input.GetKeyDown(KeyCode.M);
                kexplode = Input.GetKeyDown(KeyCode.N);
                kshoot = Input.GetKeyDown(KeyCode.P);
            
                pforward = Input.GetAxis("2LeftJoystickY");
                pright = Input.GetAxis("2LeftJoystickX");
                punch = Input.GetButtonDown("2X");
                jump = Input.GetButtonDown("2A");
                explode = Input.GetButtonDown("2Y");
                shoot = Input.GetButtonDown("2B");
                CUp = Input.GetAxis("2RightJoystickY");
                CRight = Input.GetAxis("2RightJoystickX");
            
        }
    }
    public void player3()
    {
        if (isPlayer == 3)
        {
            
                forward = Input.GetKey(KeyCode.UpArrow);
                backward = Input.GetKey(KeyCode.DownArrow);
                left = Input.GetKey(KeyCode.LeftArrow);
                right = Input.GetKey(KeyCode.RightArrow);
                kpunch = Input.GetKeyDown(KeyCode.Slash);
                kjump = Input.GetKeyDown(KeyCode.RightShift);
                kexplode = Input.GetKeyDown(KeyCode.RightAlt);
                kshoot = Input.GetKeyDown(KeyCode.RightControl);
            
            


                pforward = Input.GetAxis("3LeftJoystickY");
                pright = Input.GetAxis("3LeftJoystickX");
                punch = Input.GetButtonDown("3X");
                jump = Input.GetButtonDown("3A");
                explode = Input.GetButtonDown("3Y");
                shoot = Input.GetButtonDown("3B");
                CUp = Input.GetAxis("3RightJoystickY");
                CRight = Input.GetAxis("3RightJoystickX");
            
        }
    }
    public void player4()
    {
        if (isPlayer == 4)
        {

            forward = Input.GetKey(KeyCode.Keypad8);
            backward = Input.GetKey(KeyCode.Keypad5);
            left = Input.GetKey(KeyCode.Keypad4);
            right = Input.GetKey(KeyCode.Keypad6);
            kpunch = Input.GetKeyDown(KeyCode.Keypad7);
            kjump = Input.GetKeyDown(KeyCode.Keypad0);
            explode = Input.GetKeyDown(KeyCode.Keypad9);
            shoot = Input.GetKeyDown(KeyCode.Keypad1);

            pforward = Input.GetAxis("4LeftJoystickY");
            pright = Input.GetAxis("4LeftJoystickX");
            punch = Input.GetButtonDown("4X");
            jump = Input.GetButtonDown("4A");
            kexplode = Input.GetButtonDown("4Y");
            kshoot = Input.GetButtonDown("4B");
            CUp = Input.GetAxis("4RightJoystickY");
            CRight = Input.GetAxis("4RightJoystickX");

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        jumpset = true;
        doubleJump = true;
        canDash = false;
        particle.SetActive(false);
        dashing = false;
       
        if(collision.transform.tag == "KillZone" || collision.transform.tag == "Goal")
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
    
}

