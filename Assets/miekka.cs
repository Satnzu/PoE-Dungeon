using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class miekka : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private Playerstats stats;
    void Start()
    {
        stats = player.GetComponent<Playerstats>();
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        animator.SetTrigger("attacktrigger");
    }

    public void SetSpeed()
    {
        animator.speed = 1 - stats.Attackspeedinc;
    }

    private void OnCollisionExit(Collision collision)
    {
        Enemymob enemy = collision.gameObject.GetComponent<Enemymob>();
        if (enemy != null)
        {
            if (Random.Range(1, 100) <= stats.Critchance)
            {
                enemy.Hit(stats.Dmg * stats.Critdmg);
            }
            else
                enemy.Hit(stats.Dmg);
        }
        else
        {
            DragonBoss boss = collision.gameObject.GetComponent<DragonBoss>();
            if (boss != null)
            {
                if (Random.Range(1, 100) <= stats.Critchance)
                {
                    boss.GetHit(stats.Dmg * stats.Critdmg);
                }
                else
                    boss.GetHit(stats.Dmg);
            }
        }
        player.GetComponent<PlayerController>().ExpBarValue();
    }
}
