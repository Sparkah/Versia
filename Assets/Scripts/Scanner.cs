using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Material scannerMaterial;
    private float xOffSet=0;
    private float yOffSet=0;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private GameObject lightCone;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    private DistanceGrabbable distanceGrabbable;
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.GetComponent<Scannable>()!=null)
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        xOffSet += 0.01f;
        yOffSet += 0.01f;
        scannerMaterial.SetTextureOffset("_MainTex", new Vector2(xOffSet, yOffSet));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            light1.gameObject.SetActive(true);
            light2.gameObject.SetActive(true);
            lightCone.SetActive(true);
        }

        if(other.CompareTag("LeftArm"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            light1.gameObject.SetActive(false);
            light2.gameObject.SetActive(false);
            lightCone.SetActive(false);
        }
        if (other.CompareTag("LeftArm"))
        {
             
        }
    }
}
