using RelicsOfTheRuins.Commands;
using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class CommandExecuterInjector : MonoBehaviour, ICommandExecuterInjectable
    {
        [SerializeField]
        private GameObject []_injectionTargets;
        private CommandExecuter _commandExecuter;

        public void Inject(CommandExecuter instance)
        {
            _commandExecuter = instance;
        }

        private void Start()
        {

            if(_commandExecuter == null)
            {
                return;
            }

            if (_injectionTargets == null)
            {
                _injectionTargets = new GameObject[0];
            }
            
            foreach (GameObject obj in _injectionTargets)
            {
                ICommandExecuterInjectable[] targetLists = obj.GetComponents<ICommandExecuterInjectable>();
                foreach (ICommandExecuterInjectable target in targetLists)
                {
                    target.Inject(_commandExecuter);
                }
            }
        }
    }
}