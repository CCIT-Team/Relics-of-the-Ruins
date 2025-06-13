using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IPlayerStats
{
    private int _point = 0;
    private int _rand = 0;

    public float[] stats= { 5, 5, 5, 5, 5 };
    public float maxHealth => stats[0];
    public float maxMental => stats[1];
    public float maxStamina => stats[2];
    public float curStrength => stats[3];
    public float curSpeed => stats[4];

    public int playerDefence = 0;
    public int curDefence => playerDefence;

    private int Rand(in int inPt)
    {
        if(inPt>1)
        {
            _rand = Random.Range(-4, 2);
        }
        else if(inPt<-1)
        {
            _rand = Random.Range(-1, 5);
        }
        else
        {
            _rand = Random.Range(-4, 5);
        }

        return _rand;
    }
    public void Start()
    {
        int a = 0;
        for(int i=0;i<5;i++)
        {
            a = Rand(_point);
            _point += a;
            stats[i] =(stats[i]+a)*10;
        }

    }
}
