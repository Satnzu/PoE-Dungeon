using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymob : MonoBehaviour
{
    private float hp;
    private float maxhp;
    private float dmg;
    private float def;
    public float critchance;
    public float critdmg;
    public float lvlmultiplier;
    private float speed;
    public GameObject playerobj;
    public NavMeshAgent agent;
    private Playerstats stats;
    [SerializeField]
    Transform destination;

    void Start()
    {
        stats = playerobj.GetComponent<Playerstats>();
        RandomStats();
        hp = maxhp;
    }

    void Update()
    {
        SetDestination();
    }

    private void RandomStats()
    {
        lvlmultiplier = lvlmultiplier * stats.Playerlvl;
        maxhp = Random.Range(10, 30) * ((1 + lvlmultiplier) * stats.Playerlvl);
        dmg = Random.Range(1,5) * ((1 + lvlmultiplier) * stats.Playerlvl);
        def = Random.Range(1,3) * ((1 + lvlmultiplier) * stats.Playerlvl);
        critdmg = critdmg * ((1 + lvlmultiplier) * stats.Playerlvl);
        speed = Random.Range(1,3) * ((1 + lvlmultiplier) * stats.Playerlvl);
    }

    public void Hit(float dmg)
    {
        float incomingdmg = dmg - def;
        if (incomingdmg > 0)
        {
            hp = hp - incomingdmg;
        }
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            stats.Exp += 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            if (Random.Range(1,100) <= critchance)
            {
                player.GetHit(dmg * critdmg);
            }
            else
            {
                player.GetHit(dmg);
            }
        }
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            Vector3 target = destination.transform.position;
            agent.SetDestination(target);
        }
    }
}
