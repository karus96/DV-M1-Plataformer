using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterTemplate
{

    [SerializeField] private float _jumpForce = 5F;
    [SerializeField] private bool _ground;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _ground = true;
        }
    }
    private void Start()
    {
        _ground = false;
    }
    private void FixedUpdate()
    {
        
        if(GameManager.CurrentInstance.Status != GameStatus.Play || !_isAlive)
        {
            return;           
        }
        if (_animatorHandler.IsAnimationPlaying("Attack"))
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        
        Move(x);
    }
    private void Update()
    {
        if (!_isAlive)
        {
            return;
        }
        if (_animatorHandler.IsAnimationPlaying("Attack"))
        {
            _weapon.Attack = true;
            return;
        }
        else
        {
            _weapon.Attack = false;
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            _animatorHandler.Attack();           
            return;
        }     

        

        float jumpForce = 1;

        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump)
        {            
            jumpForce = _jumpForce;
        }

        if (jump && _ground)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        _animatorHandler.Jump(!_ground);
    }
}
