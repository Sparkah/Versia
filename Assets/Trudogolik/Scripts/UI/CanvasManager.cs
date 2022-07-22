using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Trudogolik
{
    [RequireComponent(typeof(AudioSource))]
    public class CanvasManager : MonoBehaviour
    {
        public static CanvasManager Instance { get; private set; }

        [SerializeField] private Image fadeImage;
        [Space]
        [SerializeField] private Image scareFadeAdditionalVinette;
        [SerializeField] private Image scaryFadeMain;
        [Space]
        public Sprite[] m_MainTexture;
        public Sprite[] m_AdditionalVinette;

        private int textureCount = 0;
        private int textureAmount =0;
        private float maxTextureCount;

        //fade 
        private int fadeOutTime = 1;
        private int fadeInTime = 1;

        //default scare fade values
        private float defaultImpulseSpeed = 0.1f;
        private float defaultImpulseForce = -0.1f;
        private float defaultScareFadeLevelSpeed = 1f;

        //current scare fade values
        private float currentSpeed = 1f;
        private float currentImpulseForce = -0.1f;
        private float currentImpulseSpeed = 0.1f;

        private float currentTime = 0f;
        private int maxValuePercent = 100;
        private bool isImpulse;

        private float delay = 5f;

        //audio
        private AudioSource audioS;
        private float volume;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        void Start()
        {
            audioS = GetComponent<AudioSource>();
            audioS.Play();
            audioS.volume = 0f;
            fadeImage.DOFade(0, fadeOutTime);
            maxTextureCount = (float)m_MainTexture.Length;
            textureAmount = (int)(m_MainTexture.Length / 100f * maxValuePercent);
      
            if (textureAmount > m_MainTexture.Length - 1)
                textureAmount = m_MainTexture.Length - 1;
        }

        private void Update()
        {
            if (delay <= 0)
            {
                delay = 0;
                volume = (float)textureCount / maxTextureCount;
                audioS.volume = volume;

                if (!isImpulse)
                {
                    PlayScareFade();
                }
                else
                {
                    ImpulseScareFade();
                }
            }
            delay -= Time.deltaTime;
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
                        //main texture
                        scaryFadeMain.sprite = m_MainTexture[textureCount];

                        //additional vinette
                        scareFadeAdditionalVinette.sprite = m_AdditionalVinette[textureCount];

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

                        //additional vinette
                        scareFadeAdditionalVinette.sprite = m_AdditionalVinette[textureCount];

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

        public void SetScareFadeDelay(float val)
        {
            delay = val;
        }

        public void SetScareFadeDefaultSpeed(float val)
        {
            defaultScareFadeLevelSpeed = val;
        }

        public void MakeImpulseScareFade(float force, float speed)
        {
            currentTime = 0;
            isImpulse = true;
            currentImpulseSpeed = speed;
            currentImpulseForce = force * -1; //чтобы сделать отрицательной, тк мне лень переписывать код ImpulseScareFade()   
        }

        public void SetSceneSettings(float startDelay, float scareSpeed, int percent, int fadeIn, int fadeOut)
        {
            delay = startDelay;
            defaultScareFadeLevelSpeed = scareSpeed;
            currentSpeed = scareSpeed;
            maxValuePercent = percent;
            fadeInTime = fadeIn;
            fadeOutTime = fadeOut;
        }

        public void FadeInImage()
        {
            fadeImage.DOFade(1, fadeInTime);
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

                    //additional vinette
                    scareFadeAdditionalVinette.sprite = m_AdditionalVinette[textureCount];

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
    }
}