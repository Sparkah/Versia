using UnityEngine;

namespace Trudogolik
{
    public class ScanDetector : MonoBehaviour
    {
        [SerializeField] private Material baseMaterial;
        [SerializeField] private Material greenMaterial;
        [SerializeField] private Material redMaterial;
        [SerializeField] private MeshRenderer targetMesh;

        [SerializeField] private GameObject greenLight;
        [SerializeField] private GameObject redLight;

        [SerializeField] private float duration;
        private bool isActive;
        private float currentTime = 0f;

        void Start()
        {
            SetBaseDetectorSettings();
        }

        void Update()
        {
            if (isActive) //пока активно, отсчитываетс€ таймер до деактивации
            {
                currentTime += Time.deltaTime;
                if (currentTime > duration)
                {
                    isActive = false;
                    SetBaseDetectorSettings();
                    currentTime = 0f;
                }
            }
        }

        public void DetectorRed()
        {
            if (isActive)
                return;
            targetMesh.material = redMaterial;
            redLight.SetActive(true);
            isActive = true;
        }

        public void DetectorGreen()
        {
            if (isActive)
                return;
            targetMesh.material = greenMaterial;
            greenLight.SetActive(true);
            isActive = true;
        }

        private void SetBaseDetectorSettings() //устанавливает стандартные значени€
        {
            targetMesh.material = baseMaterial;
            redLight.SetActive(false);
            greenLight.SetActive(false);
            isActive = false;
        }
    }
}