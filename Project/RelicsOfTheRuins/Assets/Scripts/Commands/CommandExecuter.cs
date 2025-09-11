using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.DataExchangeBundles;

namespace RelicsOfTheRuins.Commands
{
    public class CommandExecuter
    {
        private HashSet<CommandBase> _commands;

        public void RegisterCommand(CommandBase command)
        {
            _commands.Add(command);
        }

        public void SetActive(in CommandBase target, bool activation)
        {
            if (_commands.Contains(target))
            {
                target.Activation = activation;
            }
        }

        public bool Execute(ref MapCommandArgumentBundle refCommandArgs)
        {
            foreach (CommandBase command in _commands)
            {
                if (command.CanExecute(refCommandArgs))
                {
                    return command.Execute(ref refCommandArgs);
                }
            }

            return false;
        }

        public CommandExecuter()
        {
            _commands = new HashSet<CommandBase>();
        }

    }
}