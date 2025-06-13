using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterStats
{
    float attackRange { get; }
    float maxHealth { get; }
    float curStrength { get; }
    float defence { get; }
}
