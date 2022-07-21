using UnityEngine;
using TMPro;
using System.Collections;

namespace Trudogolik
{
    public class DigitalHandWatch : MonoBehaviour
    {
        private TextMeshProUGUI _clockTimer;
        private float _timeToSwitchScene;

        [SerializeField]  private AudioSource _audioAlarm;
        [SerializeField] private AudioClip _soundAlarm;
        [SerializeField] private SceneSettings _sceneSettings;

        //alarm
        private bool isFirstBeep = true;
        private bool isSecondBeep = true;
        private bool isThirdBeep = true;
        private int firstBeep;
        private int secondBeep;
        private int thirdBeep;
        private int fadeInTime;

        //timer
        private int _minutes;
        private int _seconds;

        void Start()
        {
            _clockTimer = GetComponentInChildren<TextMeshProUGUI>();
            _timeToSwitchScene = _sceneSettings.TimeToNextScene;
            fadeInTime = _sceneSettings.FadeInTime;
            thirdBeep = fadeInTime;
            secondBeep = fadeInTime + 1;
            firstBeep = fadeInTime + 2;

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

            Alarm();

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

        //checking for alarm and playing alarm sounds 3 seconds before fade in  starting
        private void Alarm()
        {
            if (_seconds > firstBeep)
                return;

            if (_seconds == firstBeep && isFirstBeep)
            {
                _audioAlarm.PlayOneShot(_soundAlarm);
                isFirstBeep = false;
            }
            if (_seconds == secondBeep && isSecondBeep)
            {
                _audioAlarm.PlayOneShot(_soundAlarm);
                isSecondBeep = false;
            }
            if (_seconds == thirdBeep && isThirdBeep)
            {
                _audioAlarm.PlayOneShot(_soundAlarm);
                isThirdBeep = false;
            }
        }
    }
}