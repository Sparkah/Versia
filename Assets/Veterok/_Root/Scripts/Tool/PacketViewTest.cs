using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Veterok.Views
{
    public class PacketViewTest : MonoBehaviour
    {
        public float _floatLevel = 0.0f;
        public float _floatThreshold = 2.0f;
        public float _airDensity = 0.125f;
        public float downForce = 4.0f;

        private float forceFactor;
        private Vector3 floatForce;

        
        void FixedUpdate () {
           
            forceFactor = 1.0f - ((transform.position.y - _floatLevel) / _floatThreshold);

            if (forceFactor > 0.0f) {
                floatForce = -Physics.gravity * (GetComponent<Rigidbody> ().mass * (forceFactor - GetComponent<Rigidbody> ().velocity.y * _airDensity));
            
                GetComponent<Rigidbody> ().AddForceAtPosition (floatForce, transform.position);
            }
        }

    }
}