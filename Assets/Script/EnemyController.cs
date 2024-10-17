using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterTemplate
{
    float _count;
    float _currentDirection;
    bool _player;

    // Start is called before the first frame update
    void Start()
    {
        _count=0;
        _currentDirection=0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _animatorHandler.Attack();
            _player = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_animatorHandler.IsAnimationPlaying("Attack"))
        {
            _weapon.Attack = true;
            return;
        }
        else
        {
            _weapon.Attack = false;
            _player = false;
        }
        if (_player) { return; }
        Move(_currentDirection);
        _count += Time.deltaTime;
        
        if (_count >= 1.5F)
        {
            _count = 0;
            _currentDirection = Random.Range(-1,2);
        }        
    }
}
