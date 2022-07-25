using UnityEngine;

namespace Trudogolik
{
    public class CigaretteSmoking : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _smoke;
        [SerializeField] private ParticleSystem _fire;
        [SerializeField] private float ScareFadeDelayAfterSmoke = 0;
        private TestScriptGeneralUse zagony;

        private void Start()
        {
            zagony = GetComponent<TestScriptGeneralUse>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MainCamera"))
            {
                var emission = _smoke.emission;
                emission.enabled = false;
                var fire = _fire.emission;
                fire.enabled = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("MainCamera"))
            {
                if (zagony == null)
                    return;
                zagony.ModifyZagony();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("MainCamera"))
            {
                var emission = _smoke.emission;
                emission.enabled = true;
                var fire = _fire.emission;
                fire.enabled = false;
                CanvasManager.Instance.SetScareFadeDelay(ScareFadeDelayAfterSmoke);
                CanvasManager.Instance.SetScareFadeDefault();
            }
        }
    }
}