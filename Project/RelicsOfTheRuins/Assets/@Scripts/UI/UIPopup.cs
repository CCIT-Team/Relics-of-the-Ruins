using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIPopup : UIBase
    {
        public override bool Init()
        {
            if (base.Init() == false)
            {
                return false;
            }

            return true;
        }
    }
}
