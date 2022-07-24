using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace Pigeon
{
    public class FadeInFadeOut : MonoBehaviour
    {
        [SerializeField] private Image _blackout;
        [SerializeField] private float _fadeTime = 5f;

        private void Awake()
        {
            _blackout.gameObject.SetActive(true);
        }

        private void Start()
        {
            StartCoroutine(TimerCor());
        }

        private IEnumerator TimerCor()
        {
            yield return new WaitForSeconds(_fadeTime);
            FadeOut();
        }

        public void FadeOut()
        {
            _blackout.DOFade(0, 1f);
        }

        public void FadeIn()
        {
            _blackout.DOFade(1, 1f);
        }
    }
}