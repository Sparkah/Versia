using System;
using UnityEngine;

public class ScanZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScanBox"))
        {
            var box = other.gameObject.GetComponent<Scannable>();
            
            if (box != null)
            {
                box.isInScanZone = true;
                //Debug.Log("in");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScanBox"))
        {
            var box = other.gameObject.GetComponent<Scannable>();
            if (box != null)
            {
                box.isInScanZone = false;
                //Debug.Log("out");
            }
        }
    }
}
