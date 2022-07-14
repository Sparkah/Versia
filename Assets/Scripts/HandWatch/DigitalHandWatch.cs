using UnityEngine;
using TMPro;

namespace Trudogolik
{
    public class DigitalHandWatch : MonoBehaviour
    {
        private TextMeshProUGUI _clockTimer;
        private float _timeToSwitchScene;

        [SerializeField] private SceneSettings _sceneSettings;
        void Start()
        {
            _clockTimer = GetComponentInChildren<TextMeshProUGUI>();
            _timeToSwitchScene = _sceneSettings.TimeToNextScene;
        }

        // Update is called once per frame
        void Update()
        {
            _timeToSwitchScene -= Time.deltaTime;
            int a;
            int b;

            if (_timeToSwitchScene >= 60)
            {
                a = 1;
                b = (int)_timeToSwitchScene - 60;
            }
            else
            {
                a = 0;
                b = (int)_timeToSwitchScene;
            }

            if (b < 10)
            {
                _clockTimer.text = "0" + a.ToString() + " : 0" + b.ToString();
            }
            else
            {
                _clockTimer.text = "0" + a.ToString() + " : " + b.ToString();
            }
        }
    }
}