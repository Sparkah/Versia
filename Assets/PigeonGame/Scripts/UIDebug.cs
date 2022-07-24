using UnityEngine;
using TMPro;


namespace Pigeon
{

    public class UIDebug : MonoBehaviour
    {
        [SerializeField] private TMP_Text s_fps;
        [SerializeField] private TMP_Text s_isScared;
        [SerializeField] private PigeonController _pigeonController;
        [SerializeField] private HandsSpeedChecker _handSpeedChecker;
        [SerializeField] private TMP_Text s_hand1Speed;
        [SerializeField] private TMP_Text s_hand2Speed;
        [SerializeField] private TMP_Text s_neededSpeed;
        [SerializeField] private TMP_Text s_hand1IsScaring;
        [SerializeField] private TMP_Text s_hand2IsScaring;

        private float _deltaTime;

        private void Update()
        {
            if (s_fps != null)
            {
                _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
                float fps = 1.0f / _deltaTime;
                s_fps.text = fps.ToString("0.0");
            }

            if (_pigeonController != null)
            {
                if (_pigeonController.IsScared)
                {
                    s_isScared.text = "Scared";
                }
                else
                {
                    s_isScared.text = "Not";
                }
            }

            if (_handSpeedChecker != null)
            {
                s_hand1Speed.text = _handSpeedChecker.Hand1Speed.ToString("0.0");
                s_hand2Speed.text = _handSpeedChecker.Hand2Speed.ToString("0.0");
                s_hand1IsScaring.text = _handSpeedChecker.IsCasted.ToString();
                s_hand2IsScaring.text = _handSpeedChecker.IsCasted.ToString();
                s_neededSpeed.text = _handSpeedChecker.SpeedToScare.ToString("0.0");
            }
        }


    }
}