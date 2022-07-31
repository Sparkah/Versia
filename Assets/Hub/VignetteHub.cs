using System;
using System.Collections;
using UnityEngine;

namespace Hub
{
    public class VignetteHub : Q_Vignette_Single
    {
        public bool IsFocused { get; private set; }
        
        public void ScaleVignete()
        {
            if (IsFocused) return;
            if (mainScale >= 2f)
            {
                IsFocused = true;
                return;
            }
            
            var speed = 0.5f;
            var diff = Time.deltaTime * speed;
            mainScale += diff;
        
        }

        protected override void Start()
        {
            base.Start();
            mainScale = 0;
            IsFocused = false;
        }

        IEnumerator RemoveFocus()
        {
            var speed = 2f;
        
            while (mainScale > 0)
            {
                var diff = Time.deltaTime * speed;
                mainScale -= diff;
                yield return new WaitForSeconds(0.01f);
            }

            IsFocused = false;
        }
        
        public void RemoveFocusing()
        {
            StartCoroutine(RemoveFocus());
        }
    }
}