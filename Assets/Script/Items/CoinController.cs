using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int Points;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {            
            GameManager.CurrentInstance.AddScore(Points);
            Destroy(gameObject);
        }
    }


}
