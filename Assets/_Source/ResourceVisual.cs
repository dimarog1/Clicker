using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    [SerializeField] private GameResource myGameResource;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        var observableAmount = ResourceBank.GetResource(myGameResource);
        _text.text = observableAmount.Value.ToString(); // init

        observableAmount.OnValueChanged = f => _text.text = f.ToString(); // subscription
    }
}