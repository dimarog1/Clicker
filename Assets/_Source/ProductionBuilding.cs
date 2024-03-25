using UnityEngine;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] private GameResource gameResource;
    
    public void ProduceResource()
    {
        ResourceBank.ChangeResource(gameResource, 1);
    }
}
