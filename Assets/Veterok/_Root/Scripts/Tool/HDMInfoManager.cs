using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


namespace Veterok.Tools
{
    public class HDMInfoManager : MonoBehaviour
    {
        void Start()
        {
            if (!XRSettings.isDeviceActive)
            {
                Debug.Log("No Headset plugged");
            }
            else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD"
                || XRSettings.loadedDeviceName == "MockHMDDisplay"))
                Debug.Log("Using Mock HMD");
            else
            {
                Debug.Log("We have a headset: " + XRSettings.loadedDeviceName);
            }

        }
    }
}
