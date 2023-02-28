using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Notifier
{
[Header("Player Stats")]
[SerializeField] private Rigidbody2D _rigidbody;
[SerializeField] private float health = 100f;
[SerializeField] private float speed = 1f;
[SerializeField] private float maxSpeed = 2f;
public bool isFacingRight { get; private set; } = true;
public float lastOnGroundTime { get; private set; }
private bool _isMoving = false;

private Vector2 _moveInput;

// Update is called once per frame
    private void Update()
    {
        lastOnGroundTime -= Time.deltaTime;
        Inputs();  
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            Move();
        }
    }

    private void Inputs()
    {
        if (Input.GetButton("Horizontal"))
        {
            _moveInput.x = Input.GetAxisRaw("Horizontal");
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
            //_rigidbody.velocity = Vector3.zero;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
         NotifyObservers(NotifyActions.PlayerJumped);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(x, 0, 0);
       // _rigidbody.AddForce(direction * speed, ForceMode.Impulse);
       // _rigidbody.velocity = new Vector3(x * maxSpeed, _rigidbody.velocity.y, 0);
       
    }

    private void NewMove()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float accelerationRate;
        float targetSpeed =  _moveInput.x * speed;
        float speedDifference = targetSpeed - _rigidbody.velocity.x;
    }




}
