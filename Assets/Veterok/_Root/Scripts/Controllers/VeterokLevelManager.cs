using UnityEngine;


namespace Veterok.Controllers
{
    public class VeterokLevelManager : MonoBehaviour
    {
        public static VeterokLevelManager instance;
        [SerializeField] private int _packetsToWin;
        [SerializeField] private PacketController _packetController;

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
        }

        private void OnRisedPackets(int count)
        {
            if(count >= _packetsToWin)
                StartLoadingHub();
                
        }

        private void StartLoadingHub()
        {
            
        }

        private void OnDestroy()
        {
            _packetController.RisedPackets -= OnRisedPackets;
            instance = null;
        }
    }
}