using System;
using System.Collections;
using UnityEngine;

namespace Hub
{
    public class VignetteHub : Q_Vignette_Single
    {
        public event Action Focused;
        public bool IsFocused { get; private set; }
        
        public void ScaleVignete()
        {
            if (IsFocused) return;
            if (mainScale >= 2f)
            {
                IsFocused = true;
                Focused?.Invoke();
                return;
            }
            
            var speed = 2f;
            var diff = Time.deltaTime * speed;
            mainScale += diff;
        
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