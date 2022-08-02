using ObjectOutline;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hub
{
    public class HubFigure : XRSimpleInteractable
    {
        [SerializeField] private Outline _outliner;
        [SerializeField] private string _name;
        
        public Outline Outliner => _outliner;
        public string Name => _name;
    }
}