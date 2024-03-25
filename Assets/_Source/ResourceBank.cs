using System.Collections.Generic;

public static class ResourceBank
{
    private static readonly Dictionary<GameResource, ObservableInt> Resources = new();
    private static readonly Dictionary<GameResource, ObservableInt> ResourcesLevels = new();
    
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

    public static void InitResourceLevel(GameResource r, int level)
    {
        ResourcesLevels.Add(r, new ObservableInt(level));
    }
    
    public static void UpgradeResourceLevel(GameResource r)
    {
        ResourcesLevels[r].Value++;
    }
    
    public static ObservableInt GetResourceLevel (GameResource r)
    {
        return ResourcesLevels[r];
    }
}
