using System;
using ObjectOutline;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hub
{
    public class HubGrabInteractable : XRGrabInteractable
    {
        [SerializeField] private Outline _outliner;
        [SerializeField] private int _id;
        public Outline Outliner => _outliner;
        public int Id => _id;

        private void Start()
        {
            _outliner.enabled = false;
        }

        public void ToggleOutline(bool value)
        {
            _outliner.enabled = value;
        }
    }
}