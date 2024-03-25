using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceBank
{
    private static readonly Dictionary<GameResource, ObservableInt> Resources = new();

    public static void InitResource(GameResource r, int v)
    {
        Resources.Add(r, new ObservableInt(v));

    }
    
    public static void ChangeResource(GameResource r, int v)
    {
        Resources[r].Value += v;
    }
    
    public static ObservableInt GetResource (GameResource r)
    {
        return Resources[r];
    }
}
