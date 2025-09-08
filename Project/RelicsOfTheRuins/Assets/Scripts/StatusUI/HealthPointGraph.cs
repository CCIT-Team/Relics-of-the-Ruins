using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.Utilities;
using UnityEngine;

namespace RelicsOfTheRuins.StatusUI
{
    public class HealthPointGraph : ExplorerDataSubscriberObject
    {
        private int _maxHPHalf;
        private int _maxHP;
        private CanvasRenderer _canvasRenderer;
        private RectTransform _recttransform;
        private Vector3 _maxSize, _minSize, _sizeTmp, _posTmp;

        //private HealthPointSystem _hpSystem;

        private Color _color = Color.black;



        public int testHP, testMaxHP;


        public override void ReceiveUpdate(GameObject explorer)
        {
            //체력 뽑아올 대상 변경하는 로직
            //_hpSystem = explorer.GetComponent<HealthPointSystem>();
            Debug.Log("HealthPointGraph does not implemented ReceiveUpdate\nPlease implement explorer healthPoint class!");
        }

        private void UpdateSize(int stamina)
        {
            TransformUtils.CalculateStretchTo(stamina, _maxHP, out _sizeTmp.y, ref _posTmp.y, in _minSize.y, in _maxSize.y, _recttransform.rect.height, false);
            _recttransform.position = _posTmp;
            _recttransform.sizeDelta = _sizeTmp;
        }

        private void UpdateColor(int stamina)
        {
            ColorCalculationUtils.CalculateVitalityColor(ref _color, stamina, _maxHPHalf);
            _canvasRenderer.SetColor(_color);
        }

        private void InitHPValues(int maxHP, int hp)
        {
            _maxHP = maxHP;
            _maxHPHalf = maxHP / 2;
            ColorCalculationUtils.CalculateVitalityColor(ref _color, _maxHPHalf, _maxHPHalf);
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

            InitHPValues(testMaxHP, testHP);
        }

        private void Update()
        {
            UpdateColor(testHP);
            UpdateSize(testHP);
        }
    }
}