using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charectercontroller : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 500f;
    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>(); //cache to find quickly in ram
        _animator = GetComponent<Animator>(); //caching
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                started = true;
            }
        }


         _animator.SetBool("Grounded", grounded);
        
    }

    private void FixedUpdate()
    {
        if (started)
        {
            _rigidBody2D.velocity = new Vector2(speed, _rigidBody2D.velocity.y);
        }

        if (jumping)
        {
            Debug.Log("jamp");
            _rigidBody2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
