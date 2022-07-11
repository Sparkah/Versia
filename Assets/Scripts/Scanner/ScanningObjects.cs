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
                
                if (hitBox.isInScanZone) //������� � ���� ���� � �� ��������������
                {
                    hitBox.ScanBox(); //����� �������������� ������� ������ ���� ���
                    //Debug.Log("YES");

                    //������������� ���� �� ������� ������ �� ����������� ������ �������
                    beepSound.PlayCurrentSound(hitBox.boxNumber);

                    //�������� ����� � ����������
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorGreen();
                        scanDetector2.DetectorGreen();
                    }

                    //�������� ������� �������
                    countBoxesDisplay.UpdateCounter();
                }
                else //������� �� � ���� ���� � �� ��������������
                {
                    hitBox.ScanBox(); //����� �������������� ������� ������ ���� ���
                    //Debug.Log("NO");

                    //������������� ���� ������
                    beepSound.PlayErrorSound();

                    //�������� ����� � ����������
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorRed();
                        scanDetector2.DetectorRed();
                    }

                    //�������� ������� �������
                    countBoxesDisplay.ResetCounter();
                }
            }
        }
    }
}
