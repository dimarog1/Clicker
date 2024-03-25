using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    [SerializeField] private GameResource myGameResource;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        var observableInt = ResourceBank.GetResource(myGameResource);
        _text.text = observableInt.Value.ToString(); // init
        
        observableInt.OnValueChanged = f => _text.text = f.ToString(); // subscription
    }
}