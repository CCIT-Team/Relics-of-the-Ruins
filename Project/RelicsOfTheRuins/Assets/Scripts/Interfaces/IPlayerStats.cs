using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStats
{
    float maxHealth { get; }

    float maxMental {  get; }

    float maxStamina { get; }

    float curStrength { get; }

    float curSpeed { get; }

    int curDefence { get; }
}
