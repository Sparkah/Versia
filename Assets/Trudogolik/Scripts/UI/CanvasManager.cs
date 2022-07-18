using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Trudogolik
{
    public class CanvasManager : MonoBehaviour
    {
        // [SerializeField] private Text descriptionText;
        [SerializeField] private SceneSettings sceneSettings;
        [SerializeField] private Image fadeImage;
        [Space]
        [SerializeField] private Image scareFadeAdditionalAlpha;
        [SerializeField] private Image scaryFadeMain;
        [Space]
        public Sprite[] m_MainTexture;
        public Sprite[] m_AdditionalAlpha;

        private bool canFade = true;
        private bool canAppear = true;

        private float time;
        private float scareFadeMultiplier;

        private int textureCount = 0;
        private int textureAmount;

        private int textureAdditionalCount = 0;
        private int additionalTextureAmount;

        //scene settings values
        private int timeUIToDisappear;
        private int timeUIToAppear;
        private int timeToNextScene;

        public float speed = 100f;
        private float defaulttLevelSpeed = 0.1f;
        private float impulseforce = -0.01f;
        private float impulseSpeed = 0.01f;
        private float currentTime = 0f;
        private int maxValuePercent = 80;
        private bool isImpulse;

        void Start()
        {
            //sceneSettings.SetCanvasManager(this.gameObject.GetComponent<CanvasManager>());
            //scareFadeMultiplier = sceneSettings.scareSpeedMultiplier;
            //timeUIToDisappear = sceneSettings.timeUIToDisappear;
            //timeUIToAppear = sceneSettings.timeUIToAppear;
            //timeToNextScene = sceneSettings.TimeToNextScene;

            time = 0;

            textureAmount = m_MainTexture.Length / 100 * maxValuePercent;
            if (textureAmount > m_MainTexture.Length -1)
                textureAmount = m_MainTexture.Length -1;

            //additionalTextureAmount = m_AdditionalAlpha.Length;

            //Debug.Log(m_AdditionalAlpha.Length);
            //StartCoroutine(SetMaterialTexture());
            //StartCoroutine(SetAdditionalAlphaTexture());
        }

        private void Update()
        {
            if(!isImpulse)
            {
                PlayScareFade();
            }
            else
            {
                ImpulseScareFade();
            }
            
        }

        private void PlayScareFade()
        {
            //speed = speed / 100f;
            
            if(speed >= 0) //проигрывание вперёд
            {
                currentTime += Time.deltaTime;
                if (currentTime >= speed)
                {

                    currentTime = 0f;
                    if (textureCount < textureAmount)
                    {
                        scaryFadeMain.sprite = m_MainTexture[textureCount];
                        textureCount++;
                    }
                    else
                    {
                        currentTime = 0;
                        return;
                    }
                }
            }
            else //проигрывание назад
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= speed)
                {

                    currentTime = 0f;
                    if (textureCount > 0)
                    {
                        scaryFadeMain.sprite = m_MainTexture[textureCount];
                        textureCount--;
                    }
                    else
                    {
                        currentTime = 0;
                        return;
                    }
                }
            }
            
        }

        public void MakeImpulseScareFade()
        {
            currentTime = 0;
            isImpulse = true;
            //impulseforce = impulseforce / 100f;
            //impulseSpeed = impulseSpeed / 100f;
        }

        private void ImpulseScareFade()
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= impulseforce)
            {
                impulseforce -= impulseSpeed;
                currentTime = 0f;
                if (textureCount > 0 && Mathf.Abs(impulseforce) < defaulttLevelSpeed)
                {
                    scaryFadeMain.sprite = m_MainTexture[textureCount];
                    textureCount--;
                }
                else
                {
                    //установить стандартные значения для переменных импульса
                    isImpulse = false;
                    currentTime = 0f;
                    impulseforce = -0.01f;
                    return;
                }
            }
        }















        // Use this for initialization
        //IEnumerator SetMaterialTexture()
        //{
        //    yield return new WaitForSeconds(0.2f);
        //    //15-30 = success
        //    if (textureCount < textureAmount - 1)
        //    {
        //        scaryFadeMain.sprite = m_MainTexture[textureCount];
        //        textureCount++;

        //        StartCoroutine(SetMaterialTexture());
        //    }
        //    else
        //    {
        //        StartCoroutine(SetMaterialTexture());
        //    }
        //}

        //IEnumerator SetAdditionalAlphaTexture()
        //{
        //    yield return new WaitForSeconds(0.2f);
        //    if (textureAdditionalCount < additionalTextureAmount - 1)
        //    {
        //        scareFadeAdditionalAlpha.sprite = m_AdditionalAlpha[textureAdditionalCount];
        //        textureAdditionalCount++;

        //        StartCoroutine(SetAdditionalAlphaTexture());
        //    }
        //    else
        //    {
        //        StartCoroutine(SetAdditionalAlphaTexture());
        //    }
        //}

        //void Update()
        //{
        //time += Time.deltaTime;
        //if (time > timeUIToDisappear && canAppear)
        //{
        //    canAppear = false;
        //    //descriptionText.DOFade(0, 1);
        //    fadeImage.DOFade(0, timeUIToDisappear);
        //    StartCoroutine(ScareFader());
        //}
        //if (time > timeToNextScene - timeUIToAppear && canFade)
        //{
        //    canFade = false;
        //    fadeImage.DOFade(1, timeUIToAppear);
        //}
        // }

        //private IEnumerator ScareFader()
        //{
        //    yield return new WaitForSeconds(2f);
        //    scaryFadeMain.DOFade(scareFadeMultiplier * 0.01f, 1.5f);
        //    scareFadeAdditionalAlpha.DOFade(scareFadeMultiplier * 0.09f, 1.5f);
        //    if (scareFadeMultiplier < 12f)
        //    {
        //        scareFadeMultiplier += 2.5f;
        //    }
        //    StartCoroutine(ScareFader());
        //}
        //public void DecreaseScreFader()
        //{
        //    if (scareFadeMultiplier > 1)
        //    {
        //        scareFadeMultiplier -= 1;
        //        if (textureCount > 10)
        //        {
        //            textureCount -= 10;
        //            textureAdditionalCount -= 20;
        //        }
        //        else
        //        {
        //            textureCount = 0;
        //            textureAdditionalCount = 0;
        //        }
        //    }
        //    else
        //    {
        //        scareFadeMultiplier = 0;
        //        if (textureCount > 10)
        //        {
        //            textureCount -= 10;
        //            textureAdditionalCount -= 20;
        //        }
        //        else
        //        {
        //            textureCount = 0;
        //            textureAdditionalCount = 0;
        //        }
        //    }
        //}
    }
}