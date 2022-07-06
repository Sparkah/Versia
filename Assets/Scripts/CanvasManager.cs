using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    private int timeUIToDisappear;
    private int timeUIToAppear;
    private int timeToNextScene;
    [SerializeField] private SceneSettings sceneSettings;
    private float time;
    private Image image;
    private Text descr;
    private bool canFade =true;
    private bool canAppear = true;

    void Start()
    {
        timeUIToDisappear = sceneSettings.timeUIToDisappear;
        timeUIToAppear = sceneSettings.timeUIToAppear;
        timeToNextScene = sceneSettings.TimeToNextScene;
        Debug.Log(timeUIToDisappear);
        time = 0;
        descr = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
    }

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if(time>timeUIToDisappear && canAppear)
        {
            canAppear = false;
            descr.DOFade(0, 1);
            image.DOFade(0, timeUIToDisappear);

        }
        if (time > timeToNextScene - timeUIToAppear&&canFade)
        {
            canFade = false;
            image.DOFade(1, timeUIToAppear);
        }
    }
}
