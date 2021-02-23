using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int startingHealth = 50;
    public int currentHealth;
    public int regenRate;

    //public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;

        //healthBar.SetMaxHealth(playerStartingHealth);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
    }

   


    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        //healthBar.SetHealth(playerCurrentHealth);
    }

    public void RegenHealth(int healthToGive)
    {
        currentHealth += healthToGive;
    }

    public void RegenHealthFull()
    {
        currentHealth = startingHealth;
    }

    



}