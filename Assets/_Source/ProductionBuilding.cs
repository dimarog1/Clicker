using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] private GameResource gameResource;
    [SerializeField] private Slider productionSlider;
    [SerializeField] private float productionTime = 1f;

    private Button _productionButton;
    private TextMeshProUGUI _productionButtonText;

    private void Awake()
    {
        _productionButton = GetComponent<Button>();
        _productionButtonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        var observableLevel = ResourceBank.GetResourceLevel(gameResource);
        
        _productionButtonText.text = $"+{observableLevel.Value}";
        observableLevel.OnValueChanged = f => _productionButtonText.text = $"+{f}";
    }

    public void ProduceResource()
    {
        StartCoroutine(ProductionCoroutine());
    }

    public void UpgradeResource()
    {
        StartCoroutine(UpgradeCoroutine());
    }

    private IEnumerator ProductionCoroutine()
    {
        _productionButton.interactable = false;
        productionSlider.gameObject.SetActive(true);

        var calculatedProductionTime = productionTime * (1 + ResourceBank.GetResourceLevel(gameResource).Value / 20f);

        var estimatedTime = 0f;
        while (estimatedTime < calculatedProductionTime)
        {
            estimatedTime += Time.deltaTime;
            productionSlider.value = Mathf.Lerp(productionSlider.maxValue,
                productionSlider.minValue,
                estimatedTime / calculatedProductionTime);
            yield return null;
        }

        ResourceBank.ChangeResource(gameResource, ResourceBank.GetResourceLevel(gameResource).Value);
        _productionButton.interactable = true;
        productionSlider.gameObject.SetActive(false);
    }

    private IEnumerator UpgradeCoroutine()
    {
        yield return new WaitUntil(() => _productionButton.interactable);
        
        ResourceBank.UpgradeResourceLevel(gameResource);
    }
}