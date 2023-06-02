using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager instance { get; private set; }
    [field: SerializeField] public Transform[] Points;

    private void Awake()
    {
        if (!instance) instance = this;
    }
   
}
