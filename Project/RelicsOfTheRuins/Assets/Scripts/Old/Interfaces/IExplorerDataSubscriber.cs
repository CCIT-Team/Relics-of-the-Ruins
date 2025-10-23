using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IExplorerDataSubscriber
    {
        public void ReceiveUpdate(GameObject explorer);
    }
}