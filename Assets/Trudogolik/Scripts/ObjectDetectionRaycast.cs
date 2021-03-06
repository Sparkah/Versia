using UnityEngine;

namespace Trudogolik
{
    public class ObjectDetectionRaycast : MonoBehaviour
    {
        private TestScriptGeneralUse _currentObj = null;
        private CanvasManager _canvasManager;

        void Start()
        {
            _canvasManager = CanvasManager.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.GetComponent<TestScriptGeneralUse>();
            if (obj)
            {
                _currentObj = obj;
                _currentObj.ModifyZagony();
                //Debug.Log("enter trigger");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (_currentObj != null)
            {
                _currentObj.ModifyZagony();
                //Debug.Log("trigger stay");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TestScriptGeneralUse>() == _currentObj)
            {
                _currentObj = null;
                CanvasManager.Instance.SetScareFadeDefault();
                //Debug.Log("exit stay");
            }
        }
    }
}