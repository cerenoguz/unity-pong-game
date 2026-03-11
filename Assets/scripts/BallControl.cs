using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Slider slider1;
    [SerializeField] Slider slider2;


    void GoBall()
    {
        float rand = Random.Range(0, 2);

        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(70, -0));

        } else
        {
            rb2d.AddForce(new Vector2(-70, -0));
        }

    }
    void Start ()
    {
        //GoBall();
        Invoke("GoBall", 1);
    }

    [SerializeField] GameObject Paddle1;
    [SerializeField] GameObject Paddle2;


    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        slider1.value = 0;
        slider2.value = 0;
        Paddle1.transform.position = new Vector2(Paddle1.transform.position.x,0);
        Paddle2.transform.position = new Vector2(Paddle2.transform.position.x, 0);
        GameManager._tail.enabled = true;
    }

    public void RestartGame()
    {

        ResetBall();
        Invoke("GoBall", 1);
    }

    

    Vector2 vel;

    void OnCollisionEnter2D (Collision2D other)

    {
        if (other.collider.CompareTag("Player"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = ((rb2d.velocity.y)*0.1f + (other.collider.attachedRigidbody.velocity.y));
            rb2d.velocity = vel;
        }

        //else if (other.collider.CompareTag("Wall"))
        //{
        //    vel.x = rb2d.velocity.x ;
        //    vel.y = (rb2d.velocity.y + 2);
        //    rb2d.velocity = vel;
        //}
    }
}
