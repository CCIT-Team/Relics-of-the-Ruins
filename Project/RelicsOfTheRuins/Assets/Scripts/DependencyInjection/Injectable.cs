using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class Injectable : MonoBehaviour
    {
        protected ExplorerDataHub _dataHub;

        public virtual void Inject(ExplorerDataHub instance)
        {
            _dataHub = instance;
        }
    }
}