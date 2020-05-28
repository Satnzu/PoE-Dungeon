/* 
 * platform : Unity
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public float sprintSpeed = 1000f;
    private float translation;
    private float straffe;
    private float currenthealth;
    public float maxhealth;
    public Playerstats stats;
    public GameObject miekkani;
    public GameObject player;
    public Slider healthbar;
    public Slider expbar;
    public miekka script;
    private float lvl = 0;
    private int passivePoints;
    private bool passivetree = false;
    private Playerstats copystats;
    private Transform copySpawnpoint;

    public float Currenthealth { get => currenthealth; set => currenthealth = value; }
    public float Lvl { get => lvl;}
    public int PassivePoints { get => passivePoints; set => passivePoints = value; }

    void Start () 
    {
        Cursor.lockState = CursorLockMode.Locked;
        script = miekkani.GetComponent<miekka>();
        stats = this.GetComponent<Playerstats>();
        SaveSystem playerData = new SaveSystem();
        PlayerData data = new PlayerData(playerData.LoadPlayer());
        if (data.playerData != null)
        {
            copystats = data.playerData.ConvertToStats();
        }
        else
        {
            copystats = stats;
        }
        Currenthealth = maxhealth;
    }
	void Update () 
    {
        float speedModifier = 1;
        if (Input.GetKey(KeyCode.LeftShift)) {
            speedModifier = sprintSpeed;
        } else {
            speedModifier = speed;
        }
        translation = Input.GetAxis("Vertical") * speedModifier * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speedModifier * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        //melee
        if (Input.GetMouseButton(0))
        {
            script.Attack();
        }
    }

    public void CalculateStats()
    {
        script.SetSpeed();
    }

    public void GetHit(float dmg)
    {
        float incomingdmg = dmg - stats.Def;
        if (incomingdmg > 0)
        {
            Currenthealth = Currenthealth - incomingdmg;
            int osuus = (int)Math.Round((Currenthealth / maxhealth) * 100, 0);
            healthbar.value = osuus;
        }
        if (currenthealth <= 0)
        {
            stats = copystats;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void ExpBarValue()
    {
        if (expbar.maxValue <= stats.Exp)
        {
            stats.Exp -= (int)expbar.maxValue;
            expbar.maxValue *= 1.5f;
            passivePoints++;
        }
        expbar.value = stats.Exp;
    }
}