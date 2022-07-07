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
    [SerializeField] private Image fadeImage;
    [SerializeField] private Text descriptionText;
    private bool canFade =true;
    private bool canAppear = true;
    [SerializeField] private Image scaryFadeMain;
    private float scareFadeMultiplier;

    void Start()
    {
        scareFadeMultiplier = sceneSettings.scareSpeedMultiplier;
        timeUIToDisappear = sceneSettings.timeUIToDisappear;
        timeUIToAppear = sceneSettings.timeUIToAppear;
        timeToNextScene = sceneSettings.TimeToNextScene;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time>timeUIToDisappear && canAppear)
        {
            canAppear = false;
            descriptionText.DOFade(0, 1);
            fadeImage.DOFade(0, timeUIToDisappear);
            StartCoroutine(ScareFader());
            Debug.Log("Fade Started");

        }
        if (time > timeToNextScene - timeUIToAppear&&canFade)
        {
            canFade = false;
            fadeImage.DOFade(1, timeUIToAppear);
        }
    }

    private IEnumerator ScareFader()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Fading");
        scaryFadeMain.DOFade(0.01f*scareFadeMultiplier, 5f);
        if (scareFadeMultiplier < 12f)
        {
            scareFadeMultiplier += 0.5f;
        }
        StartCoroutine(ScareFader());
    }
}
