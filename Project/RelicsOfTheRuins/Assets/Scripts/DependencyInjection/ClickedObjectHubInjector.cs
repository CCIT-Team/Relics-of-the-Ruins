using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class ClickedObjectHubInjector : MonoBehaviour
    {
        //[Space]
        [SerializeField]
        private GameObject []_injectionTargets;

        private void Awake()
        {
            ClickedObjectHub dataHubInstance = new ClickedObjectHub();

            if(dataHubInstance == null)
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
                    target.Inject(dataHubInstance);
                }
            }
        }
    }
}