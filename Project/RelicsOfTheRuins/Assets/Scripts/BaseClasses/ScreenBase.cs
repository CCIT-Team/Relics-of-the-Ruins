using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class ScreenBase : MonoBehaviour
    {
        public abstract void ProcessInput();
        public abstract void OnEnterScreen();
        public abstract void OnExitScreen();
    }
}
