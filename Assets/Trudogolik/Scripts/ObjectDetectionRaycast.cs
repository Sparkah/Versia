using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectionRaycast : MonoBehaviour
{
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TestScriptGeneralUse anyName))
        {
            //FadeImage.DoSomething
        }

        //Add here other classes to look for
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out TestScriptGeneralUse anyName) )
        {
            //FadeImage.DoSomething
        }

        //Add here other classes to look for
    }
}
