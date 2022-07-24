using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class TestScriptGeneralUse : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float delay = 0f;
        private CanvasManager _canvasManager;
        
        void Start()
        {
            _canvasManager = CanvasManager.Instance;
            
        }

        public void ModifyZagony()
        {
            //Debug.Log("modify");
            _canvasManager.SetScareFadeSpeed(speed);
            if(delay >0)
                _canvasManager.SetScareFadeDelay(delay);
        }
    }
}