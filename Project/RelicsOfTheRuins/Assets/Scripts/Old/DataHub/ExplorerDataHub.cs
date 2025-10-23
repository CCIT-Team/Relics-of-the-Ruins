using System.Collections.Generic;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataHub
    {
        private List<IExplorerDataSubscriber> _subscribers = new List<IExplorerDataSubscriber>();

        private List<IExplorerDataSubscriber> _deleteQueue = new List<IExplorerDataSubscriber>();
        private bool _bIsIterating = false;
        public void Subscribe(IExplorerDataSubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void UnSubscribe(IExplorerDataSubscriber subscriber)
        {
            if (_bIsIterating)
            {
                _deleteQueue.Add(subscriber);
            }
            else
            {
                _subscribers.Remove(subscriber);
            }
        }

        public void Publish(GameObject explorer)
        {
            _bIsIterating = true;

            foreach (IExplorerDataSubscriber target in _subscribers)
            {
                target.ReceiveUpdate(explorer);
            }

            foreach (IExplorerDataSubscriber target in _deleteQueue)
            {
                _subscribers.Remove(target);
            }

            _deleteQueue.Clear();

            _bIsIterating = false;
        }
    }
}