using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest.Models;
using Zenject;

public class ZenjectSample : MonoBehaviour
{
    [Inject]
    private Player player;

    public Player Player => player;

    void Start()
    {
        Debug.Log(player.Sword);
    }
}
