using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateFloorText : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    // Start is called before the first frame update

    public void UpdateText(in string layerName)
    {
        _tmp.text = layerName;
    }

    void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }
}
