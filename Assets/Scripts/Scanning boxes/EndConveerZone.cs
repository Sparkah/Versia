using UnityEngine;

public class EndConveerZone : MonoBehaviour
{
    [SerializeField] private BoxBeepSoundSystem beep;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScanBox"))
        {
            var box = other.gameObject.GetComponent<Scannable>();

            if (box != null)
            {
                if(box.isGetNumber == false)
                {
                    var currentBoxNumber = beep.GetNumberToBox();
                    box.SetBoxNumber(currentBoxNumber);
                }
                else
                {
                    box.ResetBox();
                }
                //Debug.Log("reset box status");
            }
        }
    }

    
}
