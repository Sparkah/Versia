using UnityEngine;

public class Scannable : MonoBehaviour
{
    [SerializeField] private Material baseMat;
    [SerializeField] private Material scanned;
    public bool isInScanZone = false;
    public bool isScanned = false;
    private MeshRenderer meshRend;

    private void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        meshRend.material = baseMat;
    }
    public void ScanBox()
    {
        isScanned = true;
        meshRend.material = scanned;
    }
    public void ResetBox()
    {
        isScanned = false;
        meshRend.material = baseMat;
    }
    


}
