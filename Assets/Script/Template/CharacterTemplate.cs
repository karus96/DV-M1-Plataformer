using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterTemplate : MonoBehaviour
{
    [SerializeField] protected int _hp;
    [SerializeField] protected int _moveSpeed;
    [SerializeField] protected int _damage;

    [SerializeField] protected Rigidbody2D _rigidbody2D;

    protected bool _isAlive;

    protected AnimatorHandler _animatorHandler;

    [SerializeField] protected WeaponController _weapon;

    public void Awake()
    {
        _isAlive = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animatorHandler = GetComponent<AnimatorHandler>();


    }

    protected void Move(float direction)
    {
        if (!_isAlive)
        {
            return;
        }       
        float x = _moveSpeed * direction;
        Vector2 movement = new Vector2(x, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;
        _animatorHandler.Move(x, x != 0);
    }

    public void ChageHP(int amount)
    {
        if (!_isAlive)
        {
            return;
        }
        _hp += amount;
        if(_hp <= 0)
        {
            _hp = 0;
            Dead();
        }
    }
    private void Dead() 
    {        
        _isAlive = false;
        _animatorHandler.Dead();
        _rigidbody2D.simulated = false;
        CapsuleCollider2D _collider2D = GetComponent<CapsuleCollider2D>();
        _collider2D.enabled = false;
    }

}
