using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private int timeUIToDisappear;
    private int timeUIToAppear;
    private int timeToNextScene;
    [SerializeField] private SceneSettings sceneSettings;
    private float time;
    [SerializeField] private Image fadeImage;
   // [SerializeField] private Text descriptionText;
    private bool canFade =true;
    private bool canAppear = true;
    [SerializeField] private Image scaryFadeMain;
    private float scareFadeMultiplier;

    void Start()
    {
        sceneSettings.SetCanvasManager(this.gameObject.GetComponent<CanvasManager>());
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
            //descriptionText.DOFade(0, 1);
            fadeImage.DOFade(0, timeUIToDisappear);
            StartCoroutine(ScareFader());
        }
        if (time > timeToNextScene - timeUIToAppear&&canFade)
        {
            canFade = false;
            fadeImage.DOFade(1, timeUIToAppear);
        }

    }

    private IEnumerator ScareFader()
    {
        yield return new WaitForSeconds(2f);
        scaryFadeMain.DOFade(0.01f*scareFadeMultiplier, 2f);
        if (scareFadeMultiplier < 12f)
        {
            scareFadeMultiplier += 0.5f;
        }
        StartCoroutine(ScareFader());
    }
    public void DecreaseScreFader()
    {
        if (scareFadeMultiplier > 1)
        {
            scareFadeMultiplier -= 1;
        }
        else
        {
            scareFadeMultiplier = 0;
        }
    }
}