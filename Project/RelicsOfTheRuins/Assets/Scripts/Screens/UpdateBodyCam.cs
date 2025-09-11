using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.Screens
{
    public class UpdateBodyCam : ExplorerDataSubscriberObject
    {
        [SerializeField]
        private RenderTexture _bodyCamRenderTexture;

        private Camera _nowCam = null;
        public override void ReceiveUpdate(GameObject explorer)
        {
            Camera camTmp = explorer.GetComponent<Camera>();

            if (camTmp == null)
            {
                camTmp = explorer.GetComponentInChildren<Camera>();
            }

            if (camTmp == null)
            {
                return;
            }

            if (_nowCam == null)
            {
                _nowCam = camTmp;
            }
            _nowCam.targetTexture = null;
            camTmp.targetTexture = _bodyCamRenderTexture;
            _nowCam = camTmp;
        }
    }
}