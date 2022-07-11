using UnityEngine;

public class ScanningObjects : MonoBehaviour
{
    [SerializeField] private LayerMask scanningLayer;
    [SerializeField] private ScanDetector scanDetector1;
    [SerializeField] private ScanDetector scanDetector2;

    [SerializeField] private BoxBeepSoundSystem beepSound;
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

                    //секция со звуком
                    beepSound.PlayCurrentSound(hitBox.boxNumber);

                    //моргание цвета у детекторов
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorGreen();
                        scanDetector2.DetectorGreen();
                    }
                }
                else //коробка НЕ в скан зоне и не просканирована
                {
                    hitBox.ScanBox(); //чтобы просканировать коробку только один раз
                    //Debug.Log("NO");

                    //секция со звуком
                    beepSound.PlayErrorSound();

                    //моргание цвета у детекторов
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorRed();
                        scanDetector2.DetectorRed();
                    }
                }
            }
        }
    }
}
