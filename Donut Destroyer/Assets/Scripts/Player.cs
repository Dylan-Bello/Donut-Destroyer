using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public Joystick joystickL;
    public Joystick joystickR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2 (joystickL.Horizontal, joystickL.Vertical);
        Vector3 lookVec = new Vector3 (joystickR.Horizontal, joystickR.Vertical, 4000);


        
        transform.Translate(moveVec * Time.deltaTime * speed, Space.World);
        transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);

    }

    
}
