
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpComponent : MonoBehaviour, IObserver
{
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float fallMulti = 2.5f;
    private bool _isGrounded;

    [SerializeField] private List<Notifier> notifiers;

    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (var notifier in notifiers)
        {
            notifier.AddObserver(this);
        }
    
    }

    private void OnDisable()
    {
        foreach (var notifier in notifiers)
        {
            notifier.RemoveObserver(this);
        }
    }
    
    private void FixedUpdate()
    {
        if (!_isGrounded)
        {
            if (rigidbody.velocity.y <= 0)
            {
                rigidbody.velocity += Vector2.up * (Physics.gravity.y * fallMulti * Time.deltaTime);
            }
        }
    }


    void Jump()
    {
        if (_isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce , ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter(Collision coll) // placeHolder
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Grounded");
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision coll) // placeHolder
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Not Grounded");
            _isGrounded = false;
        }
    }

    public void OnNotify(NotifyActions action)
    {
        if (action == NotifyActions.PlayerJumped)
        {
            Jump();
        }
    }
}