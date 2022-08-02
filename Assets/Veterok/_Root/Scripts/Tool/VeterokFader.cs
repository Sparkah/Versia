using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Veterok.Tools
{
    public class VeterokFader : MonoBehaviour
    {
        public event Action FadeOutComplete;
        public event Action FadeInComplete;
        
        [SerializeField] private Image _image;
        [SerializeField] private float _fadeSpeed;
        [SerializeField] private float _timeToFade;
        
        private IEnumerator FadingOut()
        {
            yield return new WaitForSeconds(_timeToFade);
            
            var targetColor = new Color(_image.color.r, _image.color.g, _image.color.b, 0);

            while (_image.color.a < 1)
            {
                targetColor.a += Time.deltaTime * _fadeSpeed;
                _image.color = targetColor;
                yield return null;
            }

            FadeOutComplete?.Invoke();
        }

        private IEnumerator FadingIn()
        {
            var targetColor = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
            _image.color = targetColor;
            while (_image.color.a > 0)
            {
                targetColor.a -= Time.deltaTime * _fadeSpeed;
                _image.color = targetColor;
                yield return null;
            }

            FadeInComplete?.Invoke();
        }

        public void StartFadeOut()
        {
            StartCoroutine(FadingOut());
        }

        public void StartFadeIn()
        {
            StartCoroutine(FadingIn());
        }
    }
}