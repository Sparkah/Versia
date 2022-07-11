using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    //left arm
    [SerializeField] private Light light3;
    [SerializeField] private Light light4;
    [SerializeField] private GameObject lightCone2;

    public bool nearRightHand;
    public bool nearLeftHand;

    void Update()
    {
        if(Vector3.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z)
            , new Vector3(rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z))<1f)
        {
            nearRightHand = true;
        }
        else
        {
            nearRightHand = false;
        }

        if (Vector3.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z)
    , new Vector3(leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z)) < 1f)
        {
            nearLeftHand = true;
        }
        else
        {
            nearLeftHand = false;
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
            light3.gameObject.SetActive(true);
            light4.gameObject.SetActive(true);
            lightCone2.SetActive(true);
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
            light3.gameObject.SetActive(false);
            light4.gameObject.SetActive(false);
            lightCone2.SetActive(false);
        }
        if (other.CompareTag("LeftArm"))
        {
             
        }
    }
}
