using System.Collections;
using UnityEngine;

namespace Trudogolik
{
    public class WaterTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FishFood"))
            {
                var rb = other.gameObject.GetComponent<Rigidbody>();
                rb.drag = 42f;
                rb.angularDrag = 42f;
                StartCoroutine(ReturnRbDrag(rb));
            }
        }

        IEnumerator ReturnRbDrag(Rigidbody rb)
        {
            yield return new WaitForSeconds(3f);
            rb.drag = 1;
            rb.angularDrag = 1;
        }
    }
}
//Git Head Test