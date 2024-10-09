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

    public void Awake()
    {
        _isAlive = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Move(float direction)
    {
        float x = _moveSpeed * direction;
        Vector2 movement = new Vector2(x, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;        
    }
}
