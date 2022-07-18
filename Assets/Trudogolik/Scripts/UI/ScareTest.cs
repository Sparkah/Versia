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
    // Start is called before the first frame update
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            canvasManager.speed = newSpeed;
            if(isImpulse)
            {
                canvasManager.MakeImpulseScareFade();
                isImpulse = false;
                Debug.Log("impulse");
            }
        }
    }
}