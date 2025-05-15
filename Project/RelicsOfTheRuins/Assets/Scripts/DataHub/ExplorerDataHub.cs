using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataHub
    {
        private GameObject _nowStoredExplorer;
        private List<ExplorerDataSubscriber> _subscribers = new List<ExplorerDataSubscriber>();

        private void BroadcastUpdate()
        {
            foreach(ExplorerDataSubscriber target in _subscribers)
            {
                target.ReceiveUpdate(_nowStoredExplorer);
            }
        }

        public void Subscribe(ExplorerDataSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void UnSubscribe(ExplorerDataSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Publish(GameObject explorer)
        {
            _nowStoredExplorer = explorer;
            BroadcastUpdate();
        }

    }
}