using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

namespace Pigeon
{
    public class PigeonController : MonoBehaviour
    {
        [SerializeField] private SoundsRandomizer _qooing;
        [SerializeField] private SoundsRandomizer _fliesSounds;
        [SerializeField] private TriggerZone _triggerZone;
        [SerializeField] private Transform _landPoint;
        [SerializeField] private Transform _flyPoint;
        [SerializeField] private float _flySpeed;
        [SerializeField] private float _minTime = 5f;
        [SerializeField] private float _maxTime = 15f;

        private const float k_delay = 0.2f;

        public bool Landed { get; private set; }
        public bool IsScared { get; set; }

        private void Start()
        {
            transform.position = _landPoint.position;
            StartCoroutine(OnLandCorutine());
            StartCoroutine(ScaredCorutine());
            StartCoroutine(CheckZone());
        }

        private IEnumerator OnLandCorutine()
        {
            transform.DOMove(_landPoint.position, _flySpeed);
            RotateToTarget(_landPoint.position);
            StartCoroutine(QooSounds());
            int counter = 0;
            while (!IsScared)
            {
                yield return new WaitForSeconds(k_delay);
                if (transform.position == _landPoint.position && counter == 0)
                {
                    counter++;
                    Landed = true;
                }
            }
            StopCoroutine(QooSounds());
            Landed = false;
            StartCoroutine(OnFlyCorutine());
        }

        private IEnumerator QooSounds()
        {
            yield return new WaitForSeconds(0.3f);
            _qooing.PlayRandom();
        }

        private void RotateToTarget(Vector3 target)
        {
            target.y = transform.position.y;
            transform.LookAt(target);
        }

        private IEnumerator OnFlyCorutine()
        {
            yield return new WaitForSeconds(k_delay);
            _fliesSounds.PlayRandom();
            transform.DOMove(_flyPoint.position, _flySpeed);
            RotateToTarget(_flyPoint.position);
            while (IsScared)
            {
                yield return new WaitForSeconds(k_delay);
            }
            StartCoroutine(OnLandCorutine());
        }

        public void ScarePigeon()
        {
            if (!IsScared)
            {
                IsScared = true;
                StartCoroutine(ScaredCorutine());
            }
        }

        private IEnumerator CheckZone()
        {
            while (true)
            {
                yield return new WaitForSeconds(k_delay);
                if (!IsScared)
                {
                    if (_triggerZone.IsInZone)
                    {
                        StartCoroutine(ScaredCorutine());
                        IsScared = true;
                    }
                }
            }
        }

        private IEnumerator ScaredCorutine()
        {
            float r = UnityEngine.Random.Range(_minTime, _maxTime);
            yield return new WaitForSeconds(r);
            while (_triggerZone.IsInZone)
            {
                yield return new WaitForSeconds(k_delay);
            }
            IsScared = false;
        }
    }
}