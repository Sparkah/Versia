using UnityEngine;

namespace Veterok.Tools
{
    [CreateAssetMenu(menuName = nameof(HapticEffectSettings), fileName = nameof(HapticEffectSettings))]
    public class HapticEffectSettings : ScriptableObject
    {
        public enum EffectType
        {
            OneShot,
            Continuous
        }

        [SerializeField] private EffectType Type = EffectType.Continuous;
        
        [SerializeField] private float _speedIntensity = 1f;
        [SerializeField] private AnimationCurve _curve;

        public float SpeedIntensity => _speedIntensity;
    }
}