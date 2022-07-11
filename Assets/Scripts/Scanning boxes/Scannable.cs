using UnityEngine;

public class Scannable : MonoBehaviour
{
    [SerializeField] private Material baseMat;
    [SerializeField] private Material scanned;
    public bool isInScanZone = false;
    public bool isScanned = false;
    public bool isGetNumber = false;
    private MeshRenderer meshRend;
    public int boxNumber;

    private void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        meshRend.material = baseMat;
        boxNumber = 0;
    }
    public void ScanBox()
    {
        isScanned = true;
        meshRend.material = scanned;
    }
    public void ResetBox()
    {
        isScanned = false;
        isGetNumber = false;
        boxNumber = 0;
        meshRend.material = baseMat;
    }
    public void SetBoxNumber(int num)
    {
        boxNumber = num;
        isGetNumber=true;
    }
    


}
