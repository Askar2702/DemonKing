using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "EnemyDamageForLevels", menuName = "EnemyDamageForLevels", order = 1)]
public class EnemyDamageForLevels : ScriptableObject
{
    public EnemyDamageData[] EnemyDamageDatas;
}

[Serializable]
public class EnemyDamageData
{
    public float KnigthDamage;
}
