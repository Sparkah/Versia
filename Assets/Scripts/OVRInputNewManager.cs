using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OVRInputNewManager : MonoBehaviour
{
    [SerializeField] private GameObject _leftArmScanner;
    [SerializeField] private GameObject _rightArmScanner;

    void LateStart()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.SecondaryShoulder) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            _leftArmScanner.gameObject.SetActive(false);
            _rightArmScanner.gameObject.SetActive(true);
            //_righArmScanMaesh.
        }

        if (OVRInput.Get(OVRInput.Button.Three)|| OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Button.PrimaryShoulder) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            _leftArmScanner.gameObject.SetActive(true);
            _rightArmScanner.gameObject.SetActive(false);
            //_leftArmScanMesh.
        }

        if (OVRInput.Get(OVRInput.Button.Any))
        {
            GetComponent<SceneSettings>().DecreaseCanvasFade();
        }
    }
}
