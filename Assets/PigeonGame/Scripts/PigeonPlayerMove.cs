// Copyright (C) 2014-2022 Gleechi AB. All rights reserved.
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

namespace Pigeon
{
    public class PigeonPlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController m_character = null;
        [SerializeField] private SoundsRandomizer _soundsRandomizer;
        [SerializeField] private float _speedModifier = 0.1f;
        [SerializeField] private float _rotateModifier = 0.5f;

        public bool m_verticalOnly = false;
        public bool m_horizontalOnly = true;
        [Space(15f)]
        [Header("Testing values")]
        [SerializeField] private float _stepsDelay = 0.3f;
        private Vector2 m_axisL = Vector2.zero;
        private Vector2 m_axisR = Vector2.zero;
        private Camera m_camera = null;
        public bool TestMove = false;
        public float x_speed = 1f;
        public float y_speed = 1f;

        void Start()
        {
            if (m_character == null) m_character = transform.GetComponentInParent<CharacterController>();
            m_camera = GetComponentInChildren<Camera>();
            if (m_camera == null) m_camera = Camera.main;
            if (_soundsRandomizer != null)
            {
                StartCoroutine(StepsCor());
            }
        }

        void FixedUpdate()
        {
            if (!InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out m_axisL))
                m_axisL = Vector2.zero;

            if (!InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out m_axisR))
                m_axisR = Vector2.zero;

            if (TestMove)
            {
                m_axisL = new Vector2(x_speed, y_speed);
            }

            if (m_verticalOnly)
            {
                float y = Mathf.Abs(m_axisL.y) > Mathf.Abs(m_axisR.y) ? m_axisL.y : m_axisR.y;
                if (Mathf.Abs(y) > 0.1f) m_character.Move(0.03f * y * Vector3.up);
            }
            else if (m_horizontalOnly)
            {
                float x = Mathf.Abs(m_axisL.x) > Mathf.Abs(m_axisR.x) ? m_axisL.x : m_axisR.x;
                float y = Mathf.Abs(m_axisL.y) > Mathf.Abs(m_axisR.y) ? m_axisL.y : m_axisR.y;
                Vector3 camRotation = m_camera.transform.rotation.eulerAngles;
                camRotation.x = 0;
                camRotation.z = 0;
                float gravity = 9.81f;
                Vector3 yVelocity = new Vector3(0, -0.1f, 0) * gravity;
                Quaternion newCamRotation = Quaternion.Euler(camRotation);
                if (Mathf.Abs(x) > 0.1f) m_character.transform.Rotate(new Vector3(0, _rotateModifier * x, 0), Space.Self);
                if (Mathf.Abs(y) > 0.1f) m_character.Move(_speedModifier * y * (newCamRotation * Vector3.forward) + yVelocity);
            }
            else
            {
                float x = Mathf.Abs(m_axisL.x) > Mathf.Abs(m_axisR.x) ? m_axisL.x : m_axisR.x;
                float y = Mathf.Abs(m_axisL.y) > Mathf.Abs(m_axisR.y) ? m_axisL.y : m_axisR.y;
                //if (Mathf.Abs(x) > 0.1f) m_character.Rotate(new Vector3(0, 2.0f * x, 0), Space.Self);
                if (Mathf.Abs(y) > 0.1f) m_character.Move(_speedModifier * y * (m_camera.transform.rotation * Vector3.forward));
            }
        }

        private IEnumerator StepsCor()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);

                float y = Mathf.Abs(m_axisL.y) > Mathf.Abs(m_axisR.y) ? m_axisL.y : m_axisR.y;

                if (Mathf.Abs(y) > 0.1f)
                {
                    _soundsRandomizer.PlayRandom();
                    yield return new WaitForSeconds(_stepsDelay);
                }
            }
        }
    }
}