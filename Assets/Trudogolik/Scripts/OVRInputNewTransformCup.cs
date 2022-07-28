using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class OVRInputNewTransformCup : MonoBehaviour
    {
        [SerializeField] private GameObject _leftArmCup;
        [SerializeField] private GameObject _rightArmCup;
        [SerializeField] private GameObject _leftArm;
        [SerializeField] private GameObject _rightArm;

        void Update()
        {
                if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.SecondaryShoulder) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) 
                && !(OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Button.PrimaryShoulder) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)))
                {
                if (Vector3.Distance(_rightArm.transform.position, _rightArmCup.transform.position) < 0.1f)
                {
                    _leftArmCup.gameObject.SetActive(false);
                    _rightArmCup.gameObject.SetActive(true);
                }
                }

                if (OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Button.PrimaryShoulder) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)
                &&!(OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.SecondaryShoulder) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)))
                {
                if (Vector3.Distance(_leftArm.transform.position, _leftArmCup.transform.position) < 0.1f)
                {
                    _leftArmCup.gameObject.SetActive(true);
                    _rightArmCup.gameObject.SetActive(false);
                }
            }
        }
    }
}