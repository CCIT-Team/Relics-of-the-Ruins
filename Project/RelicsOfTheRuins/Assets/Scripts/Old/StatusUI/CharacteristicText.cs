using TMPro;
using UnityEngine;

namespace RelicsOfTheRuins.StatusUI
{
    public class CharacteristicText : MonoBehaviour
    {
        private TextMeshPro _tmp;

        public void UpdateText(in string inStr)
        {
            _tmp.text = inStr;
        }

        private void Awake()
        {
            _tmp = GetComponent<TextMeshPro>();
        }
    }
}