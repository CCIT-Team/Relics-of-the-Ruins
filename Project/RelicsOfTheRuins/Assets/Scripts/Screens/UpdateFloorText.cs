using RelicsOfTheRuins.Interfaces;
using RelicsOfTheRuins.Screens;
using TMPro;
using UnityEngine;

public class UpdateFloorText : MonoBehaviour, ILayerMaskReceiver
{
    private TextMeshProUGUI _tmp;
    private string _layerName;

    public void UpdateLayerMask(in string layerName)
    {
        _layerName = layerName;
    }

    void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _tmp.text = _layerName;
    }
}