using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class CallingScript : MonoBehaviour
    {
        [SerializeField] private TriggerZone _triggerZone;
        [SerializeField] private ExitScript _exitScript;
        [SerializeField] private float _callingDelay = 30f;

        private const float k_delay = 0.1f;

        private void Start()
        {
            StartCoroutine(CheckZone());
        }

        private IEnumerator CheckZone()
        {
            while (!_triggerZone.IsInZone)
            {
                yield return new WaitForSeconds(k_delay);
            }
            StartCoroutine(CallCor());
        }

        private IEnumerator CallCor()
        {
            yield return new WaitForSeconds(_callingDelay);
            _exitScript.CallAndEnableExit();
        }
    }
}