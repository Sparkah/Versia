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
            //rb.useGravity = false;
            //var force = UnityEngine.Random.Range(0.35f, 0.42f);
            // rb.AddForce(0f, force,0f, ForceMode.Impulse);
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
    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishFood"))
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }*/
}