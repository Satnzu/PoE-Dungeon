
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonBoss : MonoBehaviour
{
    public float hp;
    public GameObject player;
    public GameObject fireballSpawner;
    public float time;
    public float attacktimer;
    public float lvlmultiplier;
    private float currentHp;
    private float dmg;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp * ((1 + lvlmultiplier) * player.GetComponent<PlayerController>().Lvl);
        dmg = Random.Range(0,50) * (1 + lvlmultiplier);
        fireballSpawner.GetComponent<FireballSpawner>().FireBallDmg(dmg);
        time = attacktimer;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        if (time <= 0)
        {
            switch (Random.Range(0,1))
            {
                case 0:
                    fireballSpawner.GetComponent<FireballSpawner>().SpawnFireball();
                    break;
                case 1:

                    break;
                case 2:

                    break;
            }
            time = attacktimer;
        }
    }

    public void GetHit(float dmg)
    {
        currentHp = currentHp - dmg;
        int osuus = (int)System.Math.Round((currentHp / hp) * 100, 0);
        healthBar.value = osuus;
        if (currentHp <= 0)
        {
            player.GetComponent<Playerstats>().Exp += 50;
            SaveSystem saveSystem = new SaveSystem();
            saveSystem.SavePlayer(player.GetComponent<Playerstats>());
            Scene thisscene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisscene.name);
        }
    }
}