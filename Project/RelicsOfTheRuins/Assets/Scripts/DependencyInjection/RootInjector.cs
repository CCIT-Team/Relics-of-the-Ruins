using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class RootInjector : MonoBehaviour
    {

        [SerializeField]
        private DataHubInjector _explorerDataHubInjector;
        [SerializeField]
        private ClickedObjectHubInjector _clickedObjectHubInjector;
        

        private void Awake()
        {
            ExplorerDataHub explorerDataHub = new ExplorerDataHub();
            ClickedObjectHub clickedObjectHub = new ClickedObjectHub();
            

            


            _explorerDataHubInjector.Inject(explorerDataHub);
            _clickedObjectHubInjector.Inject(clickedObjectHub);
            


        }
    }
}