using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllUnitUp : MonoBehaviour
{
    [SerializeField] private LevelUpUnits _levelUpUnits;
    [SerializeField] private EnemyDamageForLevels _enemyDamageForLevels;

    [Space(25)]
    [SerializeField] private Player _player;
    [SerializeField] protected Enemy _enemy;
}
