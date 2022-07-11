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
                
                if (hitBox.isInScanZone) //������� � ���� ���� � �� ��������������
                {
                    hitBox.ScanBox(); //����� �������������� ������� ������ ���� ���
                    //Debug.Log("YES");

                    //������ �� ������
                    beepSound.PlayCurrentSound(hitBox.boxNumber);

                    //�������� ����� � ����������
                    if (scanDetector1 != null && scanDetector2 != null)
                    {
                        scanDetector1.DetectorGreen();
                        scanDetector2.DetectorGreen();
                    }
                }
                else //������� �� � ���� ���� � �� ��������������
                {
                    hitBox.ScanBox(); //����� �������������� ������� ������ ���� ���
                    //Debug.Log("NO");

                    //������ �� ������
                    beepSound.PlayErrorSound();

                    //�������� ����� � ����������
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
