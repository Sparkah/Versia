using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;


namespace Veterok.Controllers
{
    public class ShooterController : MonoBehaviour
    {
        [SerializeField] private string _name;
        
        [Header("Devices")]
        private InputDevice _targetDevice;
        private List<InputDevice> _devices;
        [SerializeField] private InputDeviceCharacteristics _inputDeviceCharacteristics;
        
        [Header("Raycasting")]
        [SerializeField] private TextMeshProUGUI _debugText;
        [SerializeField] private Transform _raycastOrigin;
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private Vector3 _rayDirection;
        [SerializeField] private XRRayInteractor _xrRayInteractor;
        [SerializeField] private float _firstCast = 0;
        private float _timeToNextCast = 0.2f;

        // Start is called before the first frame update
        
        [Header("Particles")]
        private float _firstShoot = 0f;
        [SerializeField] private float _timeToNextShoot;
        [SerializeField] private Transform _rootPool;

        private bool _psActivated = false;
        private 
        void Start()
        {
            _devices = new List<InputDevice>();
            _xrRayInteractor = GetComponent<XRRayInteractor>();
            InputDevices.GetDevicesWithCharacteristics(_inputDeviceCharacteristics, _devices);
            if(_devices.Count > 0)
                _targetDevice = _devices[0];
        }

        public void SendHaptics()
        {
            _targetDevice.SendHapticImpulse(0, 0.5f, 1.5f);
        }
        
        // private void SendRayCast()
        // {
        //     var originPosition = _raycastOrigin.position;
        //     
        //     RaycastHit hit;
        //     var ray = new Ray();
        //     if (Physics.Raycast(originPosition, _raycastOrigin.forward, out hit, 100f, _targetLayer))
        //     {
        //         Debug.Log($"Hit target: {hit.collider.name} /n Hit position: {hit.point.ToString()}");
        //         var packet = hit.collider.GetComponent<PacketView>();
        //         packet.AddForce();
        //     }
        //     Debug.DrawLine(originPosition, originPosition + _raycastOrigin.forward * 10f , Color.cyan, 0.3f);
        //     //Debug.DrawRay(originPosition, _rayDirection, Color.red);
        // }
        
    }
}
