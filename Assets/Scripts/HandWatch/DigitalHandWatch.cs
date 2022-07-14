using UnityEngine;
using TMPro;
using System.Collections;

namespace Trudogolik
{
    public class DigitalHandWatch : MonoBehaviour
    {
        private TextMeshProUGUI _clockTimer;
        private float _timeToSwitchScene;

        [SerializeField] private SceneSettings _sceneSettings;

        private int _minutes;
        private int _seconds;
        void Start()
        {
            _clockTimer = GetComponentInChildren<TextMeshProUGUI>();
            _timeToSwitchScene = _sceneSettings.TimeToNextScene;
            StartCoroutine(TimeChanger());
        }

        IEnumerator TimeChanger()
        {
            CalculateMinutes();
            yield return new WaitForSeconds(1f);
            StartCoroutine(TimeChanger());
        }
        void Update()
        {
            _timeToSwitchScene -= Time.deltaTime;

            if (_seconds < 10)
            {
                _clockTimer.text = "0" + _minutes.ToString() + " : 0" + _seconds.ToString();
            }
            else
            {
                _clockTimer.text = "0" + _minutes.ToString() + " : " + _seconds.ToString();
            }
        }

        private void CalculateMinutes()
        {
            if (_timeToSwitchScene >= 60)
            {
                _minutes += 1;
                _timeToSwitchScene -= 60;
                CalculateMinutes();
            }
            else
            {
                _seconds = (int)_timeToSwitchScene;
            }

        }
    }
}