using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class OpenDoorsFinal : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("MainCamera") && OVRInput.Get(OVRInput.Button.Any))
            {
                GetComponentInParent<FinalLauncher>().StartTimeline();
            }
        }
    }
}