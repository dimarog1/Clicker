using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] private GameResource gameResource;
    [SerializeField] private Slider productionSlider;
    [SerializeField] private float productionTime = 1f;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void ProduceResource()
    {
        StartCoroutine(ProductionCoroutine());
        
    }

    private IEnumerator ProductionCoroutine()
    {
        _button.interactable = false;
        productionSlider.gameObject.SetActive(true);
        
        var estimatedTime = 0f;
        while (estimatedTime < productionTime)
        {
            estimatedTime += Time.deltaTime;
            productionSlider.value = Mathf.Lerp(productionSlider.maxValue,
                productionSlider.minValue,
                estimatedTime / productionTime);
            yield return null;
        }
        
        ResourceBank.ChangeResource(gameResource, 1);
        _button.interactable = true;
        productionSlider.gameObject.SetActive(false);

    }
}