using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaController : MonoBehaviour
{
    public int Points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterTemplate _character = collision.gameObject.GetComponent<CharacterTemplate>();
            _character.ChageHP(Points);
            Destroy(gameObject);
        }
    }
}
