using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartphoneGameManager : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    MeshRenderer myRend;
    private int materialAmount;
    private int currentMaterials;
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        materialAmount = materials.Length;
        currentMaterials = 0;
        StartCoroutine(ChangeTextureCoroutine());
    }

    private IEnumerator ChangeTextureCoroutine()
    {
        Material[] rendMaterials = myRend.materials;

        if (currentMaterials < materialAmount)
        {
            yield return new WaitForSeconds(1f);

            // Get the current material applied on the GameObject
            Material oldMaterial = rendMaterials[0];
            // Set the new material on the GameObject
            Material[] newMaterials = new Material[] { oldMaterial, materials[currentMaterials] };
            myRend.materials = newMaterials;
            currentMaterials += 1;
            StartCoroutine(ChangeTextureCoroutine());
        }
        else 
        {
            currentMaterials = 0;
            yield return new WaitForSeconds(1f);
            // Get the current material applied on the GameObject
            Material oldMaterial = rendMaterials[0];
            // Set the new material on the GameObject
            Material[] newMaterials = new Material[] { oldMaterial, materials[currentMaterials] };
            myRend.materials = newMaterials;
            StartCoroutine(ChangeTextureCoroutine());
        }
    }
}