using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class HandsAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _rightHand;
    [SerializeField] private Animator _leftHand;
    [SerializeField] private InputActionAsset _input;
    private bool _isRGrab;
    private bool _isLGrab;

    private void Start()
    {

    }

    private void SetLeftGrab()
    {
        _leftHand.SetBool("Grab", true);
        _leftHand.SetBool("Free", false);
    }
    
    private void SetLeftFree()
    {
        _leftHand.SetBool("Grab", false);
        _leftHand.SetBool("Free", true);
    }
    
    private void SetRightFree()
    {
        _rightHand.SetBool("Grab", false);
        _rightHand.SetBool("Free", true);
    }
    
    private void SetRightGrab()
    {
        _rightHand.SetBool("Grab", true);
        _rightHand.SetBool("Free", false);
    }
}
