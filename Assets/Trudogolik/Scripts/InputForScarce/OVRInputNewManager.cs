using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trudogolik
{
    public class OVRInputNewManager : MonoBehaviour
    {
        [SerializeField] private GameObject _leftArmScanner;
        [SerializeField] private GameObject _rightArmScanner;
        [SerializeField] private Scanner scanner;

        void LateStart()
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }

        private void Start()
        {
            //scanner = GetComponentInChildren<Scanner>();
        }

        void Update()
        {
            if (scanner != null)
            {
                if (scanner.nearRightHand == true && (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.SecondaryShoulder) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)))
                {
                    _leftArmScanner.gameObject.SetActive(false);
                    _rightArmScanner.gameObject.SetActive(true);
                    //_righArmScanMaesh.
                }

                if (scanner.nearLeftHand == true && (OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Button.PrimaryShoulder) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)))
                {
                    _leftArmScanner.gameObject.SetActive(true);
                    _rightArmScanner.gameObject.SetActive(false);
                    //_leftArmScanMesh.
                }
            }

            if (OVRInput.Get(OVRInput.Button.Any))
            {
                GetComponent<SceneSettings>().DecreaseCanvasFade();
            }
        }
    }
}