using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    [RequireComponent(typeof(Collider))]
    public class ImpulseScript : MonoBehaviour
    {
        [SerializeField] private float impulseForce = 0;
        [SerializeField] private float impulseSpeed = 0;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MainCamera"))
            {
                CanvasManager.Instance.MakeImpulseScareFade(impulseForce, impulseSpeed);
            }
        }
    }
}