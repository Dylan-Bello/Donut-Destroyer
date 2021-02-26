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
    private Vector2 moveVelocity;

    private PlayerHealthManager health;
    
    public Rigidbody2D player;
    public Animator anim;
    public AudioClip shootClip;

    public GameObject bulletPrefab;
    public Transform firePoint;
    
    public float bulletForce = 10f;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public My_Joystick moveJoystick;
    public My_Joystick shootJoystick;

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


       
    }

    private void FixedUpdate()
    {
        Movement();

        Rotation();
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

        ScoreManager.levelValue += level;

        Debug.Log("level" + level);
        SetXpForNextLevel();
    }

    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }



    



}
