using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class ClickedObjectHubInjector : MonoBehaviour, IClickedObjectHubInjectable
    {
        //[Space]
        [SerializeField]
        private GameObject []_injectionTargets;

        private ClickedObjectHub _dataHubInstance;

        public void Inject(ClickedObjectHub instance)
        {
            _dataHubInstance = instance;
        }

        private void Start()
        {
            if(_dataHubInstance == null)
            {
                return;
            }

            if (_injectionTargets == null)
            {
                _injectionTargets = new GameObject[0];
            }
            
            foreach (GameObject obj in _injectionTargets)
            {
                IClickedObjectHubInjectable[] targetLists = obj.GetComponents<IClickedObjectHubInjectable>();
                foreach (IClickedObjectHubInjectable target in targetLists)
                {
                    target.Inject(_dataHubInstance);
                }
            }
        }
    }
}