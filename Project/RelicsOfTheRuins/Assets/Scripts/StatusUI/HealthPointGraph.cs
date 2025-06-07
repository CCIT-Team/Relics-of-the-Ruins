using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.StatusUI
{
    public class HealthPointGraph : ExplorerDataSubscriberObject
    {
        private int _maxHPHalf;
        private int _maxHP;
        private CanvasRenderer _canvasRenderer;
        private RectTransform _recttransform;
        private Vector3 _maxHPPos, _minHPPos, _posTmp;

        //private HealthPointSystem _hpSystem;

        private Color _color = Color.black;

        public override void ReceiveUpdate(GameObject explorer)
        {
            //체력 뽑아올 대상 변경하는 로직
            //_hpSystem = explorer.GetComponent<HealthPointSystem>();
            Debug.Log("HealthPointGraph does not implemented ReceiveUpdate\nPlease implement explorer healthPoint class!");
        }

        //colorcalc클래스로 색 계산 기능 이전

        //TransformUtils클래스로 늘리기 계산 기능 이전

        private void InitHPValues(int maxHP, int hp)
        {
            _maxHP = maxHP;
            _maxHPHalf = maxHP / 2;
            _color.r = Mathf.Lerp(1, 0, (hp - _maxHPHalf) / _maxHPHalf);
            _color.g = Mathf.Lerp(0, 1, hp / _maxHPHalf);
        }

        protected override void Awake()
        {
            base.Awake();
            _canvasRenderer = GetComponent<CanvasRenderer>();
            _recttransform = GetComponent<RectTransform>();

            _maxHPPos = _recttransform.position;
            _minHPPos = _recttransform.position;
            _minHPPos.y -= _recttransform.rect.height;
            _posTmp = _maxHPPos;
        }

        private void Update()
        {
            
        }
    }
}