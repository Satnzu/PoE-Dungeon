using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float hp;
    public float def;
    public float dmg;
    public float critchance;
    public float critdmg;
    public float attackspeedinc;
    public int playerlvl;
    public int exp;
    public PlayerData playerData;

    public PlayerData (Playerstats stats)
    {
        hp = stats.Hp;
        def = stats.Def;
        dmg = stats.Def;
        critchance = stats.Critchance;
        critdmg = stats.Critdmg;
        attackspeedinc = stats.Attackspeedinc;
        playerlvl = stats.Playerlvl;
        exp = stats.Exp;
    }

    public PlayerData(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public Playerstats ConvertToStats()
    {
        Playerstats stats = new Playerstats();
        stats.Hp = hp;
        stats.Def = def;
        stats.Def = dmg;
        stats.Critchance = critchance;
        stats.Critdmg = critdmg;
        stats.Attackspeedinc = attackspeedinc;
        stats.Exp = exp;
        return stats;
    }
}
