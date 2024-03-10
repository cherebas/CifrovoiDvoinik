using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingObject : MonoBehaviour
{
    public float speed = 100;
    public float resetDestination = -30f;
    public float resetZPosition = 0f;
    public bool destroyOnReset = false;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z - speed * Time.deltaTime);

        if (!(transform.position.z <= resetDestination)) return;
        
        if (destroyOnReset)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, resetZPosition);
    }
}
