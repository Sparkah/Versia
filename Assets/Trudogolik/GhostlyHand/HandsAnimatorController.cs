using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class HandsAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _rightHand;
    [SerializeField] private Animator _leftHand;
    [SerializeField] private InputActionReference _rightTriggerInput;
    [SerializeField] private InputActionReference _leftTriggerInput;
    private const string _isGrab = "Grap";
    private const string _isFree = "Free";


    private void Start()
    {
        _rightTriggerInput.action.started += SetRightGrab;
        _leftTriggerInput.action.started += SetLeftGrab;
        _rightTriggerInput.action.canceled += SetRightFree;
        _leftTriggerInput.action.canceled += SetLeftFree;
    }
    
    private void OnDestroy()
    {
        _rightTriggerInput.action.started -= SetRightGrab;
        _leftTriggerInput.action.started -= SetLeftGrab;
        _rightTriggerInput.action.canceled -= SetRightFree;
        _leftTriggerInput.action.canceled -= SetLeftFree;
    }

    public void SetLeftGrab(InputAction.CallbackContext value)
    {
        if (_leftHand.GetCurrentAnimatorStateInfo(0).IsName(_isFree))
        {
         _leftHand.Play(_isGrab);
        }
    }
    
    public void SetLeftFree(InputAction.CallbackContext value)
    {
        if (_leftHand.GetCurrentAnimatorStateInfo(0).IsName(_isGrab))
        {
            _leftHand.Play(_isFree);
        }
    }

    public void SetRightGrab(InputAction.CallbackContext value)
    {
        if (_rightHand.GetCurrentAnimatorStateInfo(0).IsName(_isFree))
        {
            _rightHand.Play(_isGrab);
        }
    }
    
    public void SetRightFree(InputAction.CallbackContext value)
    {
        if (_rightHand.GetCurrentAnimatorStateInfo(0).IsName(_isGrab))
        {
            _rightHand.Play(_isFree);
        }
    }
}
