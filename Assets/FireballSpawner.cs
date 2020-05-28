using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject projectile;
    public Transform desti;
    public float fireballSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(desti);
    }

    public void FireBallDmg(float dmg)
    {
        projectile.GetComponent<Fireball>().damage = dmg;
    }

    public void SpawnFireball()
    {
        GameObject fireball = Instantiate(projectile, transform.position + transform.forward, Quaternion.identity) as GameObject;
        Vector3 direction = transform.forward;
        fireball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        fireball.GetComponent<Rigidbody>().AddRelativeForce(direction * fireballSpeed);
    }
}
