using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour
{
    
    
    public void moveLeft()
    {
        if(transform.position.x > -4f)
            transform.position = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
    }

    public void moveRight()
    {
        if(transform.position.x < 4f)
            transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            moveRight();
        if(Input.GetKeyDown(KeyCode.A))
            moveLeft();
    }
}
