using System.Numerics;
using UnityEngine;
using Veterok.Controllers;

namespace Veterok.Views
{
    public class CarView : MonoBehaviour
    {
        [field:SerializeField] public Transform Target { get; private set; }
        [field:SerializeField] public float Speed { get; private set; }
        public void MoveToTargetPosition(float deltaTime)
        {
            transform.localPosition += transform.forward * (deltaTime * Speed);
        }

        public void SetTarget(Transform target)=>
            Target = target;
        
    }
}