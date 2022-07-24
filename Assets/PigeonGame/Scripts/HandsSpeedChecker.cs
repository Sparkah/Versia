using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class HandsSpeedChecker : MonoBehaviour
    {
        [Header("Hands")]
        [SerializeField] private Transform _hand1;
        [SerializeField] private Transform _hand2;
        [Space(20f)]
        [Header("Settings")]
        [SerializeField] public float SpeedToScare = 1f;
        [SerializeField] private float _sphereRadius = 10f;
        [SerializeField] private LayerMask _pigeonLayer;


        public bool IsCasted;

        private Vector3 _hand1LastPos;
        private Vector3 _hand2LastPos;

        private const float k_delay = 0.2f;
        private const float k_delay2 = 0.3f;

        public float Hand1Speed { get; private set; }
        public float Hand2Speed { get; private set; }

        private void Start()
        {
            if (_hand1 != null && _hand2 != null)
            {
                _hand1LastPos = _hand1.position;
                _hand2LastPos = _hand2.position;
                StartCoroutine(HandsPosSetter());
            }
        }

        private void FixedUpdate()
        {
            if (_hand1 != null)
            {
                Hand1Speed = Vector3.Magnitude(_hand1LastPos - _hand1.position);
                if (!IsCasted && Hand1Speed > SpeedToScare)
                {
                    SphereCaster sphereCaster = new SphereCaster();
                    sphereCaster.CastSphere(transform.position, _sphereRadius, _pigeonLayer);
                    IsCasted = true;
                    StartCoroutine(HandScareDelay());
                }
            }

            if (_hand2 != null)
            {
                Hand2Speed = Vector3.Magnitude(_hand2LastPos - _hand2.position);
                if (!IsCasted && Hand2Speed > SpeedToScare)
                {
                    SphereCaster sphereCaster = new SphereCaster();
                    sphereCaster.CastSphere(transform.position, _sphereRadius, _pigeonLayer);
                    IsCasted = true;
                    StartCoroutine(HandScareDelay());
                }
            }
        }

        private IEnumerator HandScareDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(k_delay2);
                IsCasted = false;
            }
        }

        private IEnumerator HandsPosSetter()
        {
            while (true)
            {
                yield return new WaitForSeconds(k_delay);
                _hand1LastPos = _hand1.position;
                _hand2LastPos = _hand2.position;
            }
        }
    }
}