using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fireball : MonoBehaviour
{
    public float damage;

    public void SetDmg(float dmg)
    {
        damage = dmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().GetHit(damage);
        }
        else if (collision.gameObject.tag != "Dragon")
        {
            Destroy(gameObject);
        }
    }
}