using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    [SerializeField] BallControl ballController;

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            ballController.RestartGame();
        }
    }
}
