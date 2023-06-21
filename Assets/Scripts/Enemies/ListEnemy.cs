using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEnemy : MonoBehaviour
{
    public static ListEnemy instance { get; private set; }
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
    public int Count => Enemies.Count;
    public int SpawnCount { get; private set; }

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void AddEnemy(Enemy enemy)
    {
        if (!Enemies.Contains(enemy))
        {
            Enemies.Add(enemy);
            SpawnCount++;
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (Enemies.Contains(enemy)) Enemies.Remove(enemy);
        if (Enemies.Count <= 0) GameManager.instance.Finish();
    }
  
}


