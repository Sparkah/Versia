using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Veterok.Views
{
    public class PlayerView : MonoBehaviour
    {
        [Header("Right Hand interactables")]
        [SerializeField] private XRRayInteractor _rayInteractorRight;
        [SerializeField] private LineRenderer _lineRendererRight;
        [SerializeField] private XRInteractorLineVisual _xrInteractorLineVisualRight;
        
        [Header("Left Hand interactables")]        
        [SerializeField] private XRRayInteractor _rayInteractorLeft;
        [SerializeField] private LineRenderer _lineRendererLeft;
        [SerializeField] private XRInteractorLineVisual _xrInteractorLineVisualLeft;

        [Header("Vignette")] 
        [SerializeField] private Q_Vignette_Single _vignette;

        [SerializeField] private bool _isFrightened;

      
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Human")) return;
            _isFrightened = false;

        }

        private void Update()
        {
            if (_isFrightened)
            {
                ToggleActions(false);
                if (!_vignette.IsPulsating)
                {
                    _vignette.IsStopped = false;
                    _vignette.StartPulsation();
                }
                
            }
            else
            {
                ToggleActions(true);
                _vignette.IsStopped = true;
                _vignette.StopPulsation();
                _vignette.ResetMainColor();
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Human")) return;
            _isFrightened = true;

        }
        
        
        public void ToggleActions(bool isActive)
        {
            _rayInteractorLeft.enabled = isActive;
            _rayInteractorRight.enabled = isActive;
            _lineRendererLeft.enabled = isActive;
            _lineRendererRight.enabled = isActive;
            _xrInteractorLineVisualLeft.enabled = isActive;
            _xrInteractorLineVisualRight.enabled = isActive;
        }
    }
}