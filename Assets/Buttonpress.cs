using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buttonpress : MonoBehaviour
{
    public GameObject player;
    public void SetStats(Button btn)
    {
        if (player.GetComponent<PlayerController>().PassivePoints > 0)
        {
            switch (btn.tag)
            {
                case "1":
                    player.GetComponent<Playerstats>().Dmg++;
                    break;
                case "2":
                    player.GetComponent<Playerstats>().Hp += 10;
                    break;
                case "3":
                    player.GetComponent<Playerstats>().Def++;
                    break;
                case "4":
                    player.GetComponent<Playerstats>().Critchance++;
                    break;
            }
            player.GetComponent<PlayerController>().PassivePoints--;
        }
    }
}
