using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Slider slider;
    [SerializeField] GameObject paddle;
    Vector2 pos = new Vector2();
    [SerializeField] int x;
    float oldValue;
    float currentValue;
    float offSetValue;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField]Vector2 velocity;

    bool goToUP;
    bool goToDown;

    private void Awake()
    {
        pos.x = x;
        slider.value = 0;
    }
    private void Update()
    {
        pos.y = slider.value;
        paddle.transform.position = pos;


        currentValue = slider.value;
        offSetValue = oldValue - currentValue;
        oldValue = currentValue;

        velocity = rb2d.velocity;

        if (Mathf.Abs(offSetValue) < 0.001)
        {
            goToUP = false;
            goToDown = false;
        }
        else
        {
            if (offSetValue > 0)
            {
                goToDown = true;
                goToUP = false;
            }
            else
            {
                goToUP = true;
                goToDown = false;
            }
        }

        if (goToDown)
            velocity.y = -10;
        else if (goToUP)
            velocity.y = 10;
        else
            velocity.y = 0;
            

        rb2d.velocity = velocity;
    }
}
