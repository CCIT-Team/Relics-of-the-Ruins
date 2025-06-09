using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.Utilities;
using UnityEngine;

namespace RelicsOfTheRuins.StatusUI
{
    public class HealthPointGrStaminaaph : ExplorerDataSubscriberObject
    {
        private int _maxStaminaHalf;
        private int _maxStamina;
        private CanvasRenderer _canvasRenderer;
        private RectTransform _recttransform;
        private Vector3 _maxSize, _minSize, _sizeTmp, _posTmp;

        //private StaminaSystem _StaminaSystem;

        private Color _color = Color.black;



        public int testStamina;
        public int testMaxStamina;


        public override void ReceiveUpdate(GameObject explorer)
        {
            //스테미나 뽑아올 대상 변경하는 로직
            //_hpSystem = explorer.GetComponent<StaminaSystem>();
            Debug.Log("StaminaGraph does not implemented ReceiveUpdate\nPlease implement explorer Stamina class!");
        }

        private void UpdateSize(int stamina)
        {
            TransformUtils.CalculateStretchTo(stamina, _maxStamina, out _sizeTmp.x, ref _posTmp.x, in _minSize.x, in _maxSize.x, _recttransform.rect.width, false);
            _recttransform.position = _posTmp;
            _recttransform.sizeDelta = _sizeTmp;
        }

        private void UpdateColor(int stamina)
        {
            ColorCalculationUtils.CalculateVitalityColor(ref _color, stamina, _maxStaminaHalf);
            _canvasRenderer.SetColor(_color);
        }

        private void InitStaminaValues(int maxStamina, int stamina)
        {
            _maxStamina = maxStamina;
            _maxStaminaHalf = maxStamina / 2;
            ColorCalculationUtils.CalculateVitalityColor(ref _color, _maxStaminaHalf, _maxStaminaHalf);
        }

        protected override void Awake()
        {
            base.Awake();
            _canvasRenderer = GetComponent<CanvasRenderer>();
            _recttransform = GetComponent<RectTransform>();

            _minSize = Vector3.zero;
            _maxSize = _sizeTmp = _recttransform.rect.size;
            _posTmp = _recttransform.position;


            TEST_ON();
        }


        private void TEST_ON()
        {

            InitStaminaValues(testMaxStamina, testStamina);
        }

        private void Update()
        {
            UpdateColor(testStamina);
            UpdateSize(testStamina);
        }
    }
}