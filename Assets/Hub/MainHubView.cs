using System;
using UnityEngine;


namespace Hub
{
    public class MainHubView : MonoBehaviour
    {
        [SerializeField] private VignetteHub _vignette;
        
        // private void OnTriggerEnter(Collider other)
        // {
        //     if(other.CompareTag("Pigeon"))
        //     {
        //         SceneLoaderHubMain.LoadPigeonGame();
        //     }
        //
        //     if(other.CompareTag("FishFood"))
        //     {
        //         SceneLoaderHubMain.LoadTrudogolikGame();
        //     }
        //
        //     if (other.CompareTag("WindZone"))
        //     {
        //         SceneLoaderHubMain.LoadVeterokGame();
        //     }
        // }

        private void OnTriggerStay(Collider other)
        {
            HubGrabInteractable grabInteractable;
            if (other.gameObject.TryGetComponent(out grabInteractable))
            {
                if (_vignette.IsFocused)
                {
                    LoadLevelFromInteractable(grabInteractable.Name);
                }
                FocusProcess();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            HubGrabInteractable grabInteractable;
            if (other.gameObject.TryGetComponent(out grabInteractable))
            {
                _vignette.RemoveFocusing();
            }
        }

        private void FocusProcess()
        {
            _vignette.ScaleVignete();
        }

        private void LoadLevelFromInteractable(string name)
        {
            Debug.Log("Check");
            // switch (name)
            // {
            //     case "GolubNaUgin": SceneLoaderHubMain.LoadPigeonGame();
            //         break;
            //     case "Scene_1": SceneLoaderHubMain.LoadTrudogolikGame();
            //         break;
            //     case "VeterokMainScene": SceneLoaderHubMain.LoadVeterokGame();
            //         break;
            // }
        }
    }
}