using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Material scannerMaterial;
    private float xOffSet=0;
    private float yOffSet=0;
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
}
