using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trudogolik
{
    public class SceneSettings : MonoBehaviour
    {
        public int TimeToNextScene = 300;
        public int timeUIToDisappear = 5;
        public int timeUIToAppear = 5;
        [Space]
        public float ScareFadeSpeed = 1f;
        public float SceneStartDelay = 5f;
        public int SceneScareFadePercent = 100;

        private float time = 0;

        private void Awake()
        {
            CanvasManager.Instance.SetSceneSettings(SceneStartDelay, ScareFadeSpeed, SceneScareFadePercent);
        }

        public void DecreaseCanvasFade()
        {
            // canvasManager.DecreaseScreFader(); не понимаю зачем оно нужно
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time > TimeToNextScene)
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