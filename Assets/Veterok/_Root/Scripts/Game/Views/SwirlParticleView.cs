using UnityEngine;

namespace Veterok.Views
{
    public class SwirlParticleView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _swirlParticle;
        [SerializeField] private AudioSource _audioSource;

        private void Awake()
        {
            _swirlParticle.Clear();
        }

        private void Start()
        {
            _swirlParticle.Play();
            _audioSource.Play();
        }
    }
}