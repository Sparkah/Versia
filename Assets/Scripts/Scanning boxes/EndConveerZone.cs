using UnityEngine;

public class EndConveerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScanBox"))
        {
            var box = other.gameObject.GetComponent<Scannable>();

            if (box != null)
            {
                box.isScanned = false;
                //Debug.Log("reset box status");
            }
        }
    }

    
}
