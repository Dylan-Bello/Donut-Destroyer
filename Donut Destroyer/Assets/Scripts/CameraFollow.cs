using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    public float timeOffset;

    public Vector2 posOffset;

   
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

       
    }


}
