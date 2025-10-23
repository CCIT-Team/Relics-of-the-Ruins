using RelicsOfTheRuins.DataExchangeBundles;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class CommandBase
    {
        private bool _activation;
        public abstract bool CanExecute(in MapCommandArgumentBundle inCommandArgs);
        public abstract bool Execute(ref MapCommandArgumentBundle refCommandArgs);

        public bool Activation
        {
            get
            {
                return _activation;
            }
            set
            {
                _activation = value;
            }
        }
    }
}