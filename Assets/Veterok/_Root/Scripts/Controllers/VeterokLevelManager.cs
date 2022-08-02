using UnityEngine;
using Veterok.Tools;
using Veterok.Views;


namespace Veterok.Controllers
{
    public class VeterokLevelManager : MonoBehaviour
    {
        public static VeterokLevelManager instance;
        [SerializeField] private int _packetsToWin;
        [SerializeField] private PacketController _packetController;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private VeterokFader _fader;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            } else if (instance == this)
            {
                Destroy(gameObject);
            }
            
            Initialize();
        }
        
        private void Initialize()
        {
            _packetController.RisedPackets += OnRisedPackets;
            _fader.FadeOutComplete += StartLoadingHub;
            _fader.FadeInComplete += OnFadeInComplete;
            _fader.gameObject.SetActive(true);
            _fader.StartFadeIn();
        }

        private void OnFadeInComplete()
        {
            _fader.gameObject.SetActive(false);
            _playerView.ToggleHands(true);
        }
        

        private void OnRisedPackets(int count)
        {
            if(count >= _packetsToWin)
                StartFadeOut();
        }

        private void StartFadeOut()
        {
            _playerView.ToggleHands(false);
            _fader.gameObject.SetActive(true);
            _fader.StartFadeOut();
        }
        
        private void StartLoadingHub()
        {
            SceneLoaderHubMain.LoadHubMenu();
        }

        private void OnDestroy()
        {
            _packetController.RisedPackets -= OnRisedPackets;
            _fader.FadeOutComplete -= StartLoadingHub;
            instance = null;
        }

    }
}