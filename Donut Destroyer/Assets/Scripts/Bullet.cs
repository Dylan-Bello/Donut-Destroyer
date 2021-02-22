using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;

    private Vector2 dir;

    //public GameObject hitEffect;

    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        Destroy(this.gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {/*
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);*/
        //Destroy(this.gameObject);
    }


}
