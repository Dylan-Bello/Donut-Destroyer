using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    public Joystick joystick;

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
    }
}
