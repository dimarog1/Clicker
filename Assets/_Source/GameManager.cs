using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ResourceBank.InitResource(GameResource.Humans, 10);
        ResourceBank.InitResource(GameResource.Food, 5);
        ResourceBank.InitResource(GameResource.Wood, 5);
        ResourceBank.InitResource(GameResource.Stone, 0);
        ResourceBank.InitResource(GameResource.Gold, 0);
    }
    
}
