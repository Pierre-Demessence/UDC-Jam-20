using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce = 10;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnJump()
    {
        DoJump();
    }

    private void DoJump()
    {
        _rigidbody2D.AddRelativeForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}