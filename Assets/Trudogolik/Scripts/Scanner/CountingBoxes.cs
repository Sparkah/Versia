using TMPro;
using UnityEngine;

namespace Trudogolik
{
    public class CountingBoxes : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _boxCounter;
        [SerializeField] private TextMeshProUGUI _boxCounterLeft;
        private int _counter = 0;

        private void Start()
        {
            if (_boxCounter == null)
                return;
            _boxCounter.text = _counter.ToString();
            _boxCounterLeft.text = _counter.ToString();
        }
        public void UpdateCounter()
        {
            if (_boxCounter == null)
                return;
            _counter++;
            _boxCounter.text = _counter.ToString();
            _boxCounterLeft.text = _counter.ToString();
        }
        public void ResetCounter()
        {
            if (_boxCounter == null)
                return;
            _counter = 0;
            _boxCounter.text = _counter.ToString();
            _boxCounterLeft.text = _counter.ToString();
        }
    }
}