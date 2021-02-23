using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed = 1f;

    public int startingHealth = 20;
    public int currentHealth;
    public int damageToTake;


    public int scoreValue = 10;
    public int xpValue = 1;

    private Transform playerPos;
    
    
    

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = startingHealth;

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 2f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        if (currentHealth <= 0)
        {
            //ScoreManager.score += scoreValue;
            Destroy(this.gameObject);
            playerPos.GetComponent<PlayerMovement>().GainXP(xpValue);
        }

    }


    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damageToTake);

        }

    }




}
