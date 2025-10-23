using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace RelicsOfTheRuins.StatusUI
{
    public class MentalityGraph : ExplorerDataSubscriberObject
    {

        private int _maxMentality;
        private int _maxMentalityHalf;

        private CanvasRenderer _canvasRenderer;
        private Image _img;
        [SerializeField]
        private Sprite []_sprites = new Sprite[3];



        public int testMaxStamina, testStamina;



        private Color _color = Color.black;

        public override void ReceiveUpdate(GameObject explorer)
        {
            //정신도 뽑아올 대상 변경하는 로직
            //_mentalitySystem = explorer.GetComponent<MentalitySystem>();
            Debug.Log("MentalityGraph does not implemented ReceiveUpdate\nPlease implement explorer MentalitySystem class!");
        }

        private void InitStaminaValues(int maxmentality, int mentality)
        {
            _maxMentality = maxmentality;
            _maxMentalityHalf = maxmentality / 2;
            ColorCalculationUtils.CalculateVitalityColor(ref _color, _maxMentalityHalf, _maxMentalityHalf);
            UpdateFace(mentality);
        }


        private void UpdateColor(int mentality)
        {
            if (mentality < 1)
            {
                _canvasRenderer.SetColor(Color.black);
            }
            else
            {
                ColorCalculationUtils.CalculateVitalityColor(ref _color, mentality, _maxMentalityHalf);
                _canvasRenderer.SetColor(_color);
            }
        }

        private void UpdateFace(int mentality)
        {
            int mentalityRate = 100 * mentality / _maxMentality;

            if (mentalityRate > 66)
            {
                _img.sprite = _sprites[0];
            }
            else if (mentalityRate > 33)
            {
                _img.sprite = _sprites[1];
            }
            else
            {
                _img.sprite = _sprites[2];
            }
        }




        protected override void Awake()
        {
            base.Awake();
            _canvasRenderer = GetComponent<CanvasRenderer>();
            _img = GetComponent<Image>();




            TEST_ON();
        }




        private void TEST_ON()
        {

            InitStaminaValues(testMaxStamina, testStamina);
        }



        private void Update()
        {
            UpdateColor(testStamina);
            UpdateFace(testStamina);
        }
    }
}