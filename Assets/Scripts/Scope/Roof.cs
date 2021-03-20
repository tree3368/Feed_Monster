using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
                ball.DecreaseCounter();
        }
    }
}
