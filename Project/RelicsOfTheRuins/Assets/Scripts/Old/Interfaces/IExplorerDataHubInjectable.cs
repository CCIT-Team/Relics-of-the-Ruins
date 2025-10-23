using RelicsOfTheRuins.DataHub;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IExplorerDataHubInjectable
    {
        public abstract void Inject(ExplorerDataHub instance);
    }
}