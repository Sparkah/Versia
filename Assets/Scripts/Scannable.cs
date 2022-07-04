using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scannable : MonoBehaviour
{
    // Start is called before the first frame update
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
