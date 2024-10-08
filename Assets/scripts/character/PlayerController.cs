using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 basePushVector = new Vector2 (0,1);
    public float RotationSpeed;

    int enginePower = 0;
    bool engineState = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D RB2d = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (engineState)
            {
                engineState = false;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            RB2d.rotation += RotationSpeed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            RB2d.rotation -= RotationSpeed*Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D RB2d = GetComponent<Rigidbody2D>();
        updatepos(RB2d);
    }

    void updatepos(Rigidbody2D RB2d)
    {
        transform.position = transform.position + (new Vector3 (RB2d.velocity.x, RB2d.velocity.y, 0))*Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(0, 0, RB2d.rotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }

    void updatevel(Rigidbody2D RB2d)
    {
        rotation = RB2d.rotation;
        Velocity = RB2d.velocity;
        float rotationAngle = transform.eulerAngles.z * Mathf.Deg2Rad;
        float x = basePushVector.x;
        float y = basePushVector.y;
        float xrotated = (float)(x * Math.Cos(rotationAngle) - y * Math.Sin(rotationAngle));
        float yrotated = (float)(x * Math.Sin(rotationAngle) + y * Math.Cos(rotationAngle));
        RB2d.velocity = Velocity + (new Vector2(xrotated, yrotated) * Time.deltaTime);
    }
}
