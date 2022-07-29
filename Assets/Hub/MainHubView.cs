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
                    LoadLevelFromInteractable(grabInteractable.Id);
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

        private void LoadLevelFromInteractable(int id)
        {
            Debug.Log("Check");
            switch (id)
            {
                case 1: SceneLoaderHubMain.LoadPigeonGame();
                    break;
                case 2: SceneLoaderHubMain.LoadTrudogolikGame();
                    break;
                case 3: SceneLoaderHubMain.LoadVeterokGame();
                    break;
            }
        }
    }
}