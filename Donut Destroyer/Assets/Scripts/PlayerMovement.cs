using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    
    public int health = 10;
    
    public Rigidbody2D player;
    //public Camera cam;
    public Animator anim;

    public GameObject bulletPrefab;
    public Transform firePoint;
    //public float fireDelay = 0.5f;
    public float bulletForce = 10f;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public My_Joystick moveJoystick;
    public My_Joystick shootJoystick;

    private Vector2 moveVelocity;

    private bool hit = true;

    [HideInInspector]
    public bool canShoot = true;

    

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetBool("isRunning", false);
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
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        
    }

    IEnumerator HitBoxOff()
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
    /*Vector2 movement;
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
