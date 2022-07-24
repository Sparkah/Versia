using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.XR.Interaction.Toolkit;
using Veterok.Controllers;
using Veterok.Interfaces;


namespace Veterok.Views
{
    //[RequireComponent(typeof(Collider), typeof(Rigidbody))]
    internal class PacketView : MonoBehaviour, IObservable
    {
        public event Action<PacketView> PacketFadeOut;

        private HashSet<IObserver> _observers;
        private string _rising = "Rising";
        private string _falling = "Falling";
        private string _idle = "Idle";
        private string _death = "Death";

        [Header("Settings")]
        [SerializeField] private float _forceAmount;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private float _rotationTime;
        [SerializeField] private float _angle = 0;
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _risingSpeed;

        [Space] [Header("VortexSettings")] 
        [SerializeField] private float _vortexForce;
        
        
        private Vector3 _up = new(0, 1, 0);
        private Vector3 _upLeft = new(-1, 1, 0);
        private Vector3 _upRight = new(1, 1, 0);
        private Vector3 _upForward = new(0, 1, 1);
        private Vector3 _upBackWard = new(0, 1, -1);
        public bool IsDead { get; private set; }
        public bool IsGrounded { get; private set; }
        private bool _isRising;
        private List<Vector3> _directions;
        private Collider _collider;

        [Space] [Header("Attaches")] 
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _bag;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Animator _animator;
        
        private void Start()
        {
            _collider = GetComponent<Collider>();
            _directions = new List<Vector3>();
            IsDead = false;
            IsGrounded = false;
            _directions.Add(_up);
            _directions.Add(_upLeft);
            _directions.Add(_upRight);
            _directions.Add(_upForward);
            _directions.Add(_upBackWard);
        }

        private void Update()
        {
            if (IsDead) return;
            var animState = _animator.GetCurrentAnimatorStateInfo(0);
            
            if (IsGrounded)
                if(!animState.IsName(_idle))
                    _animator.Play(_idle);
            if(!IsGrounded && !_isRising)
                if(!animState.IsName(_falling))
                    _animator.Play(_falling);
            if(!IsGrounded && _isRising)
                if(!animState.IsName(_rising))
                    _animator.Play(_rising);
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.layer == 7)
            {
                if(!IsGrounded)
                    IsGrounded = true;
            }
        }
        
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.layer == 7)
            {
                if(IsGrounded)
                    IsGrounded = false;
            }
        }

        public void AddForce()
        {
            NotifyObservers();
            if(_audioSource.clip != null && !_audioSource.isPlaying) _audioSource.Play();

            StartRotation();
        }

        public void FadeOut()
        {
            StartCoroutine(Fade());
        }
        
        private void StartRotation()
        {
            var point = transform.position;

            // StopCoroutine(Rotate(point));
            // StartCoroutine(Rotate(point));
            StopCoroutine(AddVortexForce(point));
            StartCoroutine(AddVortexForce(point));
        }

        IEnumerator RotateWithTransform(Vector3 pointOfRotation)
        {
            _collider.enabled = false;
            float elapsedTime = 0f;
            var currentAngle = _angle;
            var currentRotationSpeed = _rotationSpeed;
            var rnd = Random.Range(0, 2);
           
            
            currentAngle = rnd switch
            {
                0 => -_angle,
                1 => _angle,
                _ => _angle
            };
            
            // if(!animatorInfo.IsName("Rising"))
            //     _animator.Play("Rising");
            
            while (elapsedTime < _rotationTime)
            {
                float x;
                float z;
                elapsedTime += Time.deltaTime;
                currentAngle += Time.deltaTime;
                pointOfRotation.y += Time.deltaTime * _risingSpeed;
                
                if (elapsedTime < _rotationTime / 2)
                {
                    x = Mathf.Cos(currentAngle * currentRotationSpeed) * _radius;
                    z = Mathf.Sin(currentAngle * currentRotationSpeed) * _radius;
                    transform.position = new Vector3(x, 0, z) + pointOfRotation;
                }

                if (elapsedTime >= _rotationTime / 2)
                {
                    var targetRotationSpeed = 0;
                    currentRotationSpeed -= Time.deltaTime;
                    if (currentRotationSpeed > targetRotationSpeed)
                    {
                        x = Mathf.Cos(currentAngle * currentRotationSpeed) * _radius;
                        z = Mathf.Sin(currentAngle * currentRotationSpeed) * _radius;
                        transform.position = new Vector3(x, 0, z) + pointOfRotation;
                    }
                }
                
                yield return null;
            }
            var direction = _directions[Random.Range(0, _directions.Count)];
            _rigidbody.AddForce(direction * _forceAmount, ForceMode.Impulse);
            _collider.enabled = true;
            _animator.Play("Falling");    
            _angle = 0;
        }

        IEnumerator AddVortexForce(Vector3 vortexPos)
        {
            var prevRotation = transform.rotation;
            var vortexForce = _vortexForce;
            var swirlStrength = Random.Range(5f, 8f);
            _rigidbody.drag = 10f;
            float elapsedTime = 0f;
            var pointOfRotation = vortexPos + Vector3.up * 2 + Vector3.forward * 2;

            
            Vector3 tangent;
            Vector3 postTangent = Vector3.zero;
            Vector3 postDirection = Vector3.zero;
            
            while (elapsedTime < _rotationTime)
            {
                _isRising = true;
                elapsedTime += Time.deltaTime;
                pointOfRotation.y += Time.deltaTime * _risingSpeed;
                var currTransformPos = transform.position;
                
                Vector3 swirlDir = pointOfRotation - currTransformPos;
                tangent = Vector3.Cross(swirlDir, Vector3.up).normalized * swirlStrength;
                _rigidbody.velocity = tangent;
                
                Vector3 direction = pointOfRotation - currTransformPos;
                _rigidbody.AddForce(direction.normalized * (Time.deltaTime * vortexForce));
                postTangent = tangent;
                postDirection = direction;
                yield return null;
            }

            // _rigidbody.velocity = postTangent;
            // _rigidbody.AddForce(postDirection.normalized * Time.deltaTime * vortexForce);
            //transform.rotation = prevRotation;
            
            _isRising = false;
        }

        private IEnumerator Fade()
        {
            //Renderer rend = transform.GetComponent<SkinnedMeshRenderer>();
            Color initialColor = _renderer.material.color;
            Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

            float elapsedTime = 0f;

            while (elapsedTime < _fadeOutDuration)
            {
                elapsedTime += Time.deltaTime;
                _renderer.material.color = Color.Lerp(initialColor, targetColor, elapsedTime / _fadeOutDuration);
                yield return null;
            }
            PacketFadeOut?.Invoke(this);
        }

        public void AddLinearForce(float force)
        {
            _rigidbody.AddForce(Vector3.left * force, ForceMode.Impulse);
        }
        
        public void Die(Vector3 position)
        {
            IsDead = true;
            var yOfsset = 0.4f;
            GetComponent<XRSimpleInteractable>().enabled = false;
            GetComponent<Collider>().enabled = false;
            transform.rotation = Quaternion.identity;
            _rigidbody.isKinematic = true;
            transform.position = new Vector3(transform.position.x, position.y + yOfsset, transform.position.z);
            _animator.Play(_death);
        }
        

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnEnable()
        {
            GetComponent<XRSimpleInteractable>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }

        public void AddObserver(IObserver o)
        {
            if (_observers == null)
            {
                _observers= new HashSet<IObserver>();
            }

            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer.Update(gameObject);
        }
        
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}