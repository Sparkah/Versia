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


        //default scare fade values
        private float defaultImpulseSpeed = 0.1f;
        private float defaultImpulseForce = -0.1f;
        private float defaultScareFadeLevelSpeed = 1f;


        private float currentSpeed = 1f;
        private float currentImpulseForce = -0.1f;
        private float currentImpulseSpeed = 0.1f;

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
            if (textureAmount > m_MainTexture.Length - 1)
                textureAmount = m_MainTexture.Length - 1;

            //additionalTextureAmount = m_AdditionalAlpha.Length;

            //Debug.Log(m_AdditionalAlpha.Length);
            //StartCoroutine(SetMaterialTexture());
            //StartCoroutine(SetAdditionalAlphaTexture());
        }

        private void Update()
        {
            if (!isImpulse)
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
            if (currentSpeed >= 0) //проигрывание вперёд
            {
                currentTime += Time.deltaTime * 10;
                if (currentTime >= currentSpeed)
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
                currentTime -= Time.deltaTime * 10;
                if (currentTime <= currentSpeed)
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
        public void SetScareFadeSpeed(float speed)
        {
            currentSpeed = speed;
        }

        public void MakeImpulseScareFade(float force, float speed)
        {
            currentTime = 0;
            isImpulse = true;
            currentImpulseSpeed = speed;
            currentImpulseForce = force * -1; //чтобы сделать отрицательной, тк мне лень переписывать код ImpulseScareFade()   
        }

        private void ImpulseScareFade()
        {
            currentTime -= Time.deltaTime * 10;
            if (currentTime <= currentImpulseForce)
            {
                currentImpulseForce -= currentImpulseSpeed;
                currentTime = 0f;
                if (textureCount > 0 && Mathf.Abs(currentImpulseForce) < defaultScareFadeLevelSpeed)
                {
                    scaryFadeMain.sprite = m_MainTexture[textureCount];
                    textureCount--;
                }
                else
                {
                    //имульс закончен. установить стандартные значения для переменных импульса и текущего времени
                    isImpulse = false;
                    currentTime = 0f;
                    currentImpulseForce = defaultImpulseForce;
                    currentImpulseSpeed = defaultImpulseSpeed;
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