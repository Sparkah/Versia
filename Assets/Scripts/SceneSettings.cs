using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public int TimeToNextScene = 300;
    private float time = 0;
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time>TimeToNextScene)
        {
            if(boxCollider!=null)
            {
                Destroy(boxCollider);
            }
        }
}
}
