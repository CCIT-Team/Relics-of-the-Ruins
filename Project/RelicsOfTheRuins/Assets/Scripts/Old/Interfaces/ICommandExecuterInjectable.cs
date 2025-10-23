
using RelicsOfTheRuins.Commands;

namespace RelicsOfTheRuins.Interfaces
{
    public interface ICommandExecuterInjectable
    {
        public abstract void Inject(CommandExecuter instance);
    }
}