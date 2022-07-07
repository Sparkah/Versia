using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WaterTrigger : MonoBehaviour
{
   // [SerializeField] private float force = 0.1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishFood"))
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            var force = UnityEngine.Random.Range(0.35f, 0.42f);
            rb.AddForce(0f, force,0f, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishFood"))
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }
}