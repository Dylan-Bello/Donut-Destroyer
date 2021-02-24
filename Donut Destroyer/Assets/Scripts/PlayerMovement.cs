using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float xp = 0;
    public float xpForNextLevel = 10;
    public int level = 1;

    public float moveSpeed = 7f;

    private PlayerHealthManager health;
    //public int health = 10;
    
    public Rigidbody2D player;
    //public Camera cam;
    public Animator anim;
    public AudioClip shootClip;

    public GameObject bulletPrefab;
    public Transform firePoint;
    //public float fireDelay = 0.5f;
    public float bulletForce = 10f;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public My_Joystick moveJoystick;
    public My_Joystick shootJoystick;

    private Vector2 moveVelocity;

    //private bool hit = true;

    [HideInInspector]
    public bool canShoot = true;

    private void Start()
    {
        SetXpForNextLevel();
    }

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetBool("isRunning", false);

        
        health = this.GetComponent<PlayerHealthManager>();
    }

    private void Update()
    {
        Rotation();

        //Shoot Function
        if (Input.GetMouseButton(0) && (Time.time > nextFire) && canShoot)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        //Level Up
        if (xp >= xpForNextLevel)
        {
            LevelUp();
            health.RegenHealthFull();
        }


        //Bounds
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, ., ), MathfClamp(transform.position.y., ));
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(moveJoystick.InputDir != Vector3.zero)
            moveInput = moveJoystick.InputDir;
        
        moveVelocity = moveInput.normalized * moveSpeed;
        player.MovePosition(player.position + moveVelocity * Time.fixedDeltaTime);

        if (moveVelocity == Vector2.zero)
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", true);
    }

    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (shootJoystick.InputDir != Vector3.zero)
            angle = Mathf.Atan2(shootJoystick.InputDir.y, shootJoystick.InputDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        SoundManager.instance.PlayShootFX(shootClip);
        
    }

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }

    void LevelUp()
    {
        xp = 0f;
        level++;

        Debug.Log("level" + level);
        SetXpForNextLevel();
    }

    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }


    /*IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            if (hit)
            {
                StartCoroutine(HitBoxOff());
                health--;
            }
            
        }
    }
    Vector2 movement;
    Vector2 mousePos;



    // Input Methods
   void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }
 
    // Functions
    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //isRunning = true;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }*/
}
