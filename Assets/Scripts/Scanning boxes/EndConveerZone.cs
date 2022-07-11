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
                box.ResetBox();
                //Debug.Log("reset box status");
            }
        }
    }

    
}
