using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPlayer : MonoBehaviour
{
    public static ListPlayer instance { get; private set; }
    public List<Player> Players { get; private set; } = new List<Player>();
    public int Count => Players.Count;
    public int SpawnCount { get; private set; }
    public int LossesCount { get; private set; }
    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void AddPlayer(Player player)
    {
        if (!Players.Contains(player))
        {
            Players.Add(player);
            SpawnCount++;
        }
    }

    public void RemovePlayer(Player player)
    {
        if (Players.Contains(player))
        {
            Players.Remove(player);
            LossesCount++;
        }
    }
}
