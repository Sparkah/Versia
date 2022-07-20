using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trudogolik
{
    public class SceneSettings : MonoBehaviour
    {
        public int TimeToNextScene = 300;
       
        public int FadeInTime = 5;
        public int FadeOutTime = 5;
        [Space]
        public float ScareFadeSpeed = 1f;
        public float SceneCareFadeStartDelay = 5f;
        public int SceneScareFadePercent = 100;

        private float currentTime = 0;
        private bool canFade = true;

        private void Awake()
        {
            //set scene settings to canvas manager singleton
            CanvasManager.Instance.SetSceneSettings(SceneCareFadeStartDelay, ScareFadeSpeed, SceneScareFadePercent, FadeInTime, FadeOutTime);
        }

        public void DecreaseCanvasFade()
        {
            // canvasManager.DecreaseScreFader(); не понимаю зачем оно нужно
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            //start fading before loading next scene
            if (currentTime > TimeToNextScene - FadeInTime && canFade)
            {
                canFade = false;
                CanvasManager.Instance.FadeInImage();
            }
   
            if (currentTime > TimeToNextScene)
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
}