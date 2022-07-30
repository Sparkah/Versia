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
                //outline.enabled = false;
                outline.OutlineColor = Color.white;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Outline"))
            {
                _outline = GetComponentsInChildren<Outline>();
                foreach (var outline in _outline)
                {
                    Debug.Log("Trigger entered");
                    outline.OutlineColor = new Color(0,0.72f,1,1);
                }
            }
        }

        /*private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Outline"))
            {
                _outline = GetComponentsInChildren<Outline>();
                foreach (var outline in _outline)
                {
                    Debug.Log("Trigger staying");
                    outline.OutlineColor = new Color(185, 255, 255,1);
                }
            }
        }*/

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Outline"))
            {
                _outline = GetComponentsInChildren<Outline>();
                foreach (var outline in _outline)
                {
                    outline.OutlineColor = Color.white;
                }
            }
        }
    }
}