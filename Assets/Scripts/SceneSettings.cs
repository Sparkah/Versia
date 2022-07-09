using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public int TimeToNextScene = 300;
    public int timeUIToDisappear = 5;
    public int timeUIToAppear = 5;
    public int scareSpeedMultiplier;

    private float time = 0;
    private CanvasManager canvasManager;

public void SetCanvasManager(CanvasManager _canvas)
    {
        canvasManager = _canvas;
    }
    public void DecreaseCanvasFade()
    {
        canvasManager.DecreaseScreFader();
    }    

    private void Update()
    {
        time += Time.deltaTime;
        if(time>TimeToNextScene)
        {
            if (SceneChangeSystem.current < SceneManager.sceneCountInBuildSettings)
            {
                SceneChangeSystem.NextScene();
            }
            else
            {
                SceneManager.LoadScene(0);
                SceneChangeSystem.current = 0;
            }
        }
    }
}