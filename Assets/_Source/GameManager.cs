using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ResourceBank.AddResource(GameResource.Humans, 10);
        ResourceBank.AddResource(GameResource.Food, 5);
        ResourceBank.AddResource(GameResource.Wood, 5);
        ResourceBank.AddResource(GameResource.Stone, 0);
        ResourceBank.AddResource(GameResource.Gold, 0);
    }
    
}
