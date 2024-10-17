using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int Damage;
    public bool Attack;
    public string TagTarget;


    private void Awake()
    {
        Attack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (!Attack) 
        {
            return;
        }

        if (collision.gameObject.CompareTag(TagTarget))
        {
            CharacterTemplate character = collision.gameObject.GetComponent<CharacterTemplate>();            
            character.ChageHP(-Damage);
        }
    }

}
