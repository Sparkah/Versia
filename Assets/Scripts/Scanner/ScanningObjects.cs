using UnityEngine;
[RequireComponent(typeof(CountingBoxes))]
public class ScanningObjects : MonoBehaviour
{
    [SerializeField] private LayerMask scanningLayer;

    [SerializeField] private ScanDetector scanDetector1;
    [SerializeField] private ScanDetector scanDetector2;

    private CountingBoxes countBoxesDisplay;

    [SerializeField] private BoxBeepSoundSystem beepSound;

    private void Start()
    {
        countBoxesDisplay = GetComponent<CountingBoxes>();
    }
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, scanningLayer))
        {
            var hitBox = hit.transform.gameObject.GetComponent<Scannable>();
            if (hitBox != null && hitBox.isScanned == false) 
            {
                
                if (hitBox.isInScanZone) //коробка в скан зоне и не просканирована
                {
                    hitBox.ScanBox(); //чтобы просканировать коробку только один раз
                    //Debug.Log("YES");

                    //воспроизвести звук из массива звуков по порядковому номеру коробки
                    beepSound.PlayCurrentSound(hitBox.boxNumber);

                    //моргание цвета у детекторов
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorGreen();
                        scanDetector2.DetectorGreen();
                    }

                    //обновить счётчик коробок
                    countBoxesDisplay.UpdateCounter();
                }
                else //коробка НЕ в скан зоне и не просканирована
                {
                    hitBox.ScanBox(); //чтобы просканировать коробку только один раз
                    //Debug.Log("NO");

                    //воспроизвести звук ошибки
                    beepSound.PlayErrorSound();

                    //моргание цвета у детекторов
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorRed();
                        scanDetector2.DetectorRed();
                    }

                    //обновить счётчик коробок
                    countBoxesDisplay.ResetCounter();
                }
            }
        }
    }
}
