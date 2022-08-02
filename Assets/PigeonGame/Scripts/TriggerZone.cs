using UnityEngine;
using UnityEditor.XR.LegacyInputHelpers;

namespace Pigeon
{
    public class TriggerZone : MonoBehaviour
    {
        public bool IsInZone { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsInZone = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsInZone = false;
            }
        }
    }
}
