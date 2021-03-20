using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speedStart;

    private Rigidbody2D _rigidbody2D;
    private Ball _ball;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _ball = GetComponent<Ball>();
    }

    private void OnMouseDown()
    {
        if(_ball.Player.CurrentEnerge >= _ball.Player.EnergyCosts)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _ball.Player.ReduceEnergy();
        }
    }

    private void OnEnable()
    {
        _rigidbody2D.AddForce(new Vector2(_ball.Target.position.x - transform.position.x, 0) * _speedStart, ForceMode2D.Impulse);
    }
}
