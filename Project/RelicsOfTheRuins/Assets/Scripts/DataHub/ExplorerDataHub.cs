using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataHub
    {
        private GameObject _nowStoredExplorer;
        private List<ExplorerDataSubscriber> _subscribers = new List<ExplorerDataSubscriber>();

        private List<ExplorerDataSubscriber> _deleteQueue = new List<ExplorerDataSubscriber>();
        private bool _bIsIterating = false;

        private void BroadcastUpdate()
        {
            _bIsIterating = true;

            foreach (ExplorerDataSubscriber target in _subscribers)
            {
                target.ReceiveUpdate(_nowStoredExplorer);
            }

            foreach (ExplorerDataSubscriber target in _deleteQueue)
            {
                _subscribers.Remove(target);
            }

            _deleteQueue.Clear();

            _bIsIterating = false;
        }

        public void Subscribe(ExplorerDataSubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void UnSubscribe(ExplorerDataSubscriber subscriber)
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
            _nowStoredExplorer = explorer;
            BroadcastUpdate();
        }

    }
}