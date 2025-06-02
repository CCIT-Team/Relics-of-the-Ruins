using RelicsOfTheRuins.DataHub;

namespace RelicsOfTheRuins.DependencyInjection
{
    public interface IClickedObjectHubInjectable
    {
        public abstract void Inject(ClickedObjectHub instance);
    }
}