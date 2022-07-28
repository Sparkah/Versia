using UnityEngine;

namespace Trudogolik
{
    public class PlayerCheckObjectDestroyer : MonoBehaviour
    {
        [SerializeField] private float _impulseForce;
        [SerializeField] private float _impulseSpeed;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CanvasManager.Instance.MakeImpulseScareFade(_impulseForce, _impulseSpeed);
                Destroy(gameObject);
            }
            
        }
    }
}