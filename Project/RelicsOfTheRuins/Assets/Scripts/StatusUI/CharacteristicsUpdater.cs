using RelicsOfTheRuins.DataHub;
using UnityEngine;


namespace RelicsOfTheRuins.StatusUI
{
    public class CharacteristicsUpdater : ExplorerDataSubscriberObject
    {
        [SerializeField]
        private CharacteristicText[] _texts;
        public override void ReceiveUpdate(GameObject explorer)
        {
            //특성 뽑아와서 배포하는 로직
            Debug.Log("CharacteristicText does not implemented ReceiveUpdate\nPlease implement explorer Characteristic class!");
        }

        private void UpdateTexts(in string[] characteristics)
        {
            for (int i = 0; i < _texts.Length && i < characteristics.Length; i++)
            {
                _texts[i].UpdateText(characteristics[i]);
            }
        }

    }
}

