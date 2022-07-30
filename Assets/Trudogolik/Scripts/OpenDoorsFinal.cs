using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class OpenDoorsFinal : MonoBehaviour
    {
        [SerializeField] private float _timeToNextScene;
        private bool _isActivated = false;

        private void Update()
        {
            _timeToNextScene -= Time.deltaTime;
            if(_timeToNextScene<=0 && !_isActivated)
            {
                _isActivated = true;
                GetComponentInParent<FinalLauncher>().StartTimeline();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("MainCamera") && (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.SecondaryShoulder) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
                || !(OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Button.PrimaryShoulder) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !_isActivated))
            {
                _isActivated = true;
                GetComponentInParent<FinalLauncher>().StartTimeline();
            }
        }
    }
}