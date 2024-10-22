using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int Points;
    public bool _oneUse = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player") && !_oneUse)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            GameManager.CurrentInstance.AddScore(Points);
            _oneUse = true;
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false; 
            Animator animator = gameObject.GetComponent<Animator>();
            animator.enabled = false;
            
        }
    }


}
