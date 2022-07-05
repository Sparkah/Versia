using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public int TimeToNextScene = 300;
    private float time = 0;
    //private Clock clock;

    private void Start()
    {
        //clock = GetComponentInChildren<Clock>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time>TimeToNextScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
}
