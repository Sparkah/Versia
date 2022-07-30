using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectOutline;

namespace Trudogolik
{
    public class RaycastOutlineCheck : MonoBehaviour
    {
        private Outline[] _outline;
        private void Start()
        {
            _outline = GetComponentsInChildren<Outline>();
            foreach (var outline in _outline)
            {
                outline.enabled = false;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Outline"))
            {
                foreach (var outline in _outline)
                {
                    outline.enabled = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Outline"))
            {
                foreach (var outline in _outline)
                {
                    outline.enabled = false;
                }
            }
        }
    }
}