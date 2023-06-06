using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private enum TypeParent { Player , Enemy};
    [SerializeField] private float _damage = 25f;
    [SerializeField] private TypeParent _typeParent;

    private void OnTriggerEnter(Collider other)
    {
        //if (_typeParent == TypeParent.Player)
        //{
        //    if (other.TryGetComponent(out Enemy enemy)) enemy.TakeDamage(_damage);
        //}
    }
}
