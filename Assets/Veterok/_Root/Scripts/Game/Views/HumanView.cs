using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Veterok.Views
{
    public class HumanView : MonoBehaviour
    {
        public event Action<HumanView> HumanFadeOut;
        [Header("Settings")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private Transform _character;
        
        [Header("Animation/Sounds")]
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioClip _burchanie;
        private AudioSource _audioSource;
        
        [Header("AI")]
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        private Vector3 _targetWayPoint;
        private Renderer _renderer;
        private bool _faded = false;
        private string _isAngry = "isAngry";

        public NavMeshAgent NavAgent => _navMeshAgent;
        
        
        private void Start()
        {
            _renderer = GetComponentInChildren<Renderer>();
            _animator = GetComponentInChildren<Animator>();
            _audioSource = GetComponent<AudioSource>();
            if(_burchanie != null)
                _audioSource.clip = _burchanie;
            _navMeshAgent.speed = _moveSpeed;
        }

        public void SetWayPoint(Vector3 position) => 
            _navMeshAgent.destination = position;

        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var playerView = other.gameObject.GetComponent<PlayerView>();
                Interaction(playerView);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StopAllCoroutines();
                StartCoroutine(WaitToStartWalking());
            }
        }
        
        private void Interaction(PlayerView view)
        {
            _navMeshAgent.isStopped = true;
            StartCoroutine(LookAtPlayer(view));
            _animator.SetBool(_isAngry, true);
            _audioSource.Play();
        }

        private IEnumerator LookAtPlayer(PlayerView player)
        {
            while (true)
            {
                var targetDirection = player.transform.position - transform.position;
                targetDirection.y = 0;
                Quaternion rotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed);
                yield return null;
            }
        }

        public void FadeOut()
        {
            StartCoroutine(FadeOutCoroutine());
        }
        
        
        private IEnumerator FadeOutCoroutine()
        {
            var initialColor = _renderer.material.color;
            Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

            float elapsedTime = 0f;

            while (elapsedTime < _fadeOutDuration)
            {
                elapsedTime += Time.deltaTime;
                _renderer.material.color = Color.Lerp(initialColor, targetColor, elapsedTime / _fadeOutDuration);
                yield return null;
            }
            HumanFadeOut?.Invoke(this);
        }

        IEnumerator WaitToStartWalking()
        {
            yield return new WaitForSeconds(2f);
            _navMeshAgent.isStopped = false;
            _animator.SetBool(_isAngry, false);
            _audioSource.Stop();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}