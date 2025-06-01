using RelicsOfTheRuins.Commands;
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
        [SerializeField]
        private CommandExecuterInjector _commandExecuterInjector;

        private void Awake()
        {
            ExplorerDataHub explorerDataHub = new ExplorerDataHub();
            ClickedObjectHub clickedObjectHub = new ClickedObjectHub();
            CommandExecuter commandExecuter = new CommandExecuter();

            clickedObjectHub.Inject(commandExecuter);


            _explorerDataHubInjector.Inject(explorerDataHub);
            _clickedObjectHubInjector.Inject(clickedObjectHub);
            _commandExecuterInjector.Inject(commandExecuter);


        }
    }
}