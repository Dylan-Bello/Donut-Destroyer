using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float moveSpeed = 15f;
    public float rotationSpeed = 10;

    public int startingHealth = 20;
    public int currentHealth;
    public int damageToTake;


    public int scoreValue = 10;
    public int xpValue = 1;

    private Transform playerPos;
    private Rigidbody2D rb;

    public AudioClip deathClip;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = startingHealth;

        

    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 2f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);

        if (currentHealth <= 0)
        {
            //ScoreManager.score += scoreValue;
            Destroy(this.gameObject);
            SoundManager.instance.PlaySoundFX(deathClip);
            playerPos.GetComponent<PlayerMovement>().GainXP(xpValue);
        }

        Vector3 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);

        UpdateRotation(rotation);
        

    }

    void UpdateRotation(Vector3 angle)
    {
        Quaternion rotation = Quaternion.Euler(angle);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
    }

    




}
