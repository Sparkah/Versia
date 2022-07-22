using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Trudogolik
{
    public class ScareTest : MonoBehaviour
    {
        public CanvasManager canvasManager;
        public float newSpeed;
        public bool isImpulse;
        public float impulseForce = 0.1f;
        public float impulseSpeed = 0.1f;


        void Update()
        {
            canvasManager.SetScareFadeSpeed(newSpeed);
            if (isImpulse)
            {
                canvasManager.MakeImpulseScareFade(impulseForce, impulseSpeed);
                isImpulse = false;
                Debug.Log("impulse");
            }
        }
    }
}