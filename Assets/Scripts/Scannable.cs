using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scannable : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveX(20,40);
    }

    private void Update()
    {
        if(transform.position.x>20)
        {
            Destroy(gameObject);
        }
    }
}
