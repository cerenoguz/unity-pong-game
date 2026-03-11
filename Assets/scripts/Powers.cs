using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{

    public int playerSizeUp;
    public int playerSizeDown;
    public int playerSizeFireBall;

    public void SizeUp(GameObject _myPedal)
    {
        if (playerSizeUp == 0)
        {
            StartCoroutine(SizeUpWait(_myPedal));
        }
        ++playerSizeUp;
    }

    public void SizeDown(GameObject _enemyPaddle)
    {
        if (playerSizeDown == 0)
        {
            StartCoroutine(SizeDownWait(_enemyPaddle));
        }
        ++playerSizeDown;
    }

    public void FireBall(Rigidbody2D _ballRigidBody)
    {
        if (playerSizeFireBall == 0)
        {
            Vector2 vel = _ballRigidBody.velocity;
            _ballRigidBody.velocity = vel * 3;
        }
        
        ++playerSizeFireBall;
    }

    IEnumerator SizeUpWait(GameObject _myPedal)
    {
        var firstScale = _myPedal.transform.localScale;
        _myPedal.transform.localScale  = new Vector3(_myPedal.transform.localScale.x, _myPedal.transform.localScale.y * 2, _myPedal.transform.localScale.z);
        yield return new WaitForSeconds(5);
        _myPedal.transform.localScale = firstScale;
    }

    IEnumerator SizeDownWait(GameObject _myPedal)
    {
        var firstScale = _myPedal.transform.localScale;
        _myPedal.transform.localScale = new Vector3(_myPedal.transform.localScale.x, _myPedal.transform.localScale.y * 0.5f, _myPedal.transform.localScale.z);
        yield return new WaitForSeconds(5);
        _myPedal.transform.localScale = firstScale;
    }
}
