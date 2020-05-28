using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats : MonoBehaviour
{
    private float hp = 100;
    private float def = 0;
    private float dmg = 5;
    private float critchance = 5;
    private float critdmg = 1.5f;
    private float attackspeedinc = 0;
    private int playerlvl = 1;
    private int exp = 0;

    public float Hp { get => hp; set => hp = value; }
    public float Def { get => def; set => def = value; }
    public float Dmg { get => dmg; set => dmg = value; }
    public float Critchance { get => critchance; set => critchance = value; }
    public float Critdmg { get => critdmg; set => critdmg = value; }
    public float Attackspeedinc { get => attackspeedinc; set => attackspeedinc = value; }
    public int Exp { get => exp; set => exp = value; }
    public int Playerlvl { get => playerlvl; set => playerlvl = value; }
}
