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
    public Sprite[] m_MainTexture;
    public Sprite[] m_AdditionalAlpha;
    private int textureCount = 0;
    private int textureAdditionalCount = 0;
    private int textureAmount;
    private int additionalTextureAmount;
    [SerializeField] private Image scareFadeAdditionalAlpha;

    void Start()
    {
        sceneSettings.SetCanvasManager(this.gameObject.GetComponent<CanvasManager>());
        scareFadeMultiplier = sceneSettings.scareSpeedMultiplier;
        timeUIToDisappear = sceneSettings.timeUIToDisappear;
        timeUIToAppear = sceneSettings.timeUIToAppear;
        timeToNextScene = sceneSettings.TimeToNextScene;
        time = 0;
        textureAmount = m_MainTexture.Length;
        additionalTextureAmount = m_AdditionalAlpha.Length;
        Debug.Log(m_AdditionalAlpha.Length);
        StartCoroutine(SetMaterialTexture());
        StartCoroutine(SetAdditionalAlphaTexture());
    }


    // Use this for initialization
    IEnumerator SetMaterialTexture()
    {
        yield return new WaitForSeconds(0.2f);
        //15-30 = success
        if (textureCount < textureAmount - 1)
        {
            scaryFadeMain.sprite= m_MainTexture[textureCount];
            textureCount++;

            StartCoroutine(SetMaterialTexture());
        }
        else
        {
            StartCoroutine(SetMaterialTexture());
        }
    }

    IEnumerator SetAdditionalAlphaTexture()
    {
        yield return new WaitForSeconds(0.2f);
        if (textureAdditionalCount < additionalTextureAmount - 1)
        {
            scareFadeAdditionalAlpha.sprite = m_AdditionalAlpha[textureAdditionalCount];
            textureAdditionalCount++;

            StartCoroutine(SetAdditionalAlphaTexture());
        }
        else
        {
            StartCoroutine(SetAdditionalAlphaTexture());
        }
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
        scaryFadeMain.DOFade(scareFadeMultiplier*0.01f, 1.5f);
        scareFadeAdditionalAlpha.DOFade(scareFadeMultiplier * 0.09f, 1.5f);
        if (scareFadeMultiplier < 12f)
        {
            scareFadeMultiplier += 2.5f;
        }
        StartCoroutine(ScareFader());
    }
    public void DecreaseScreFader()
    {
        if (scareFadeMultiplier > 1)
        {
            scareFadeMultiplier -= 1;
            if (textureCount > 10)
            {
                textureCount -= 10;
                textureAdditionalCount -= 20;
            }
            else
            {
                textureCount = 0;
                textureAdditionalCount = 0;
            }
        }
        else
        {
            scareFadeMultiplier = 0;
            if (textureCount > 10)
            {
                textureCount -= 10;
                textureAdditionalCount -= 20;
            }
            else
            {
                textureCount = 0;
                textureAdditionalCount = 0;
            }
        }
    }
}