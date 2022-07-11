using UnityEngine;

public class ScanningObjects : MonoBehaviour
{
    [SerializeField] private LayerMask scanningLayer;
    [SerializeField] private ScanDetector scanDetector1;
    [SerializeField] private ScanDetector scanDetector2;
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, scanningLayer))
        {
            var hitBox = hit.transform.gameObject.GetComponent<Scannable>();
            if (hitBox != null && hitBox.isScanned == false)
            {
                //попали в коробку, вы€сн€ем в скан зоне она или нет
                if (hitBox.isInScanZone)
                {
                    hitBox.isScanned = true; //чтобы просканировать коробку только один раз
                    //Debug.Log("YES");

                    //секци€ со звуком

                    //эффект попадани€ (моргание света нужного цвета)
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorGreen();
                        scanDetector2.DetectorGreen();
                    }
                }
                else
                {
                    hitBox.isScanned = true; //чтобы просканировать коробку только один раз
                    //Debug.Log("NO");

                    //секци€ со звуком

                    //эффект попадани€ (моргание света нужного цвета)
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
