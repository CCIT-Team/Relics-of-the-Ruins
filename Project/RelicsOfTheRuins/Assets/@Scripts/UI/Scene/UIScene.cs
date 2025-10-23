

using Manager;

namespace UI.Scene
{
    public class UIScene : UIBase
    {
        public override bool Init()
        {
            if (base.Init() == false)
            {
                return false;
            }

            Managers.Instance.UIManager.SetCanvas(gameObject, false);
            return true;
        }
    }
}