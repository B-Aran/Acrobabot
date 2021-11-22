using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform PlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //We move our camera only in the X direction
        //transform.position.Set(PlayerPosition.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(PlayerPosition.position.x, transform.position.y, transform.position.z);
    }
}
