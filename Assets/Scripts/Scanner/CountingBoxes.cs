using TMPro;
using UnityEngine;

public class CountingBoxes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _boxCounter;
    private int _counter = 0;

    private void Start()
    {
        if (_boxCounter == null)
            return;
        _boxCounter.text =_counter.ToString(); 
    }
    public void UpdateCounter()
    {
        if(_boxCounter == null)
            return;
        _counter++;
        _boxCounter.text = _counter.ToString();
    }
    public void ResetCounter()
    {
        if (_boxCounter == null)
            return;
        _counter = 0;
        _boxCounter.text = _counter.ToString();
    }
}
