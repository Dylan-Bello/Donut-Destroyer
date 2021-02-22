using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    public float timeOffset;

    public Vector2 posOffset;

    //private Vector3 velocity;



    //public Transform playerCamera;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Cameras current position
        Vector3 startPos = transform.position;

        //Players current position
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //move topwards player
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(endPos.x, -700f, 920f),
            Mathf.Clamp(endPos.y, -50f, 185f), transform.position.z);
    }


    /* if(playerCamera != null)
     {
         Vector3 playerPos = playerCamera.position;
         playerPos.z = transform.position.z;
         transform.position = playerPos;
     }*/
}
