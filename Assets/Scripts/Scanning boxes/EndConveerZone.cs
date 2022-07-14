using UnityEngine;

namespace Trudogolik
{
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
                    if (box.isGetNumber == false) //коробка в начале линии. присваиваем коробке порядковый номер, чтобы впоследствии извлечь звук сканирования по этому номеру
                    {
                        var currentBoxNumber = beep.GetNumberToBox();
                        box.SetBoxNumber(currentBoxNumber);
                    }
                    else // коробка доехала до конца линии, сбрасываем её настройки
                    {
                        box.ResetBox();
                    }
                    //Debug.Log("reset box status");
                }
            }
        }


    }
}