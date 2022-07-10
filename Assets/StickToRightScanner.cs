using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToRightScanner : MonoBehaviour
{
    [SerializeField] private GameObject _rightScanner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _rightScanner.transform.position;
    }
}
