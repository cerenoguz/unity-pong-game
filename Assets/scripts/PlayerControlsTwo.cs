using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsTwo : MonoBehaviour
{
    public float speed = 10.0f;
    public float boundY = 2.24f;
    private Rigidbody2D rb2d;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var vel = rb2d.velocity;
        if (UIControl.Instance.isUpTwo)
        {
            vel.y = speed;
        }
        else if (UIControl.Instance.isDownTwo)
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;

    }
}
