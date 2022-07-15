using UnityEngine;

namespace Trudogolik
{
    public class PlayerCheckObjectDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}