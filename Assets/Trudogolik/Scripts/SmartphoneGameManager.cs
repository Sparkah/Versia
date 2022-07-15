using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class SmartphoneGameManager : MonoBehaviour
    {
        [SerializeField] private Material[] materials;
        //Set these Textures in the Inspector
        public Texture[] m_MainTexture;
        Renderer m_Renderer;
        private int textureCount = 0;
        private int textureAmount;
        private AudioSource _audiSource;

        void Start()
        {
            _audiSource = GetComponent<AudioSource>();
            m_Renderer = GetComponent<Renderer>();
            textureAmount = m_MainTexture.Length;
            StartCoroutine(SetMaterialTexture());
        }

        // Use this for initialization
        IEnumerator SetMaterialTexture()
        {
            //15-30 = success
            if (textureCount < textureAmount - 1)
            {
                yield return new WaitForSeconds(0.1f);
                m_Renderer.materials[1].SetTexture("_MainTex", m_MainTexture[textureCount]);
                textureCount++;

                StartCoroutine(SetMaterialTexture());
            }
            else
            {
                textureCount = 0;
                StartCoroutine(SetMaterialTexture());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && textureCount >= 15 && textureCount <= 30)
            {
                m_Renderer.materials[1].color = Color.green;
                StartCoroutine(ReturnColor());
            }
            else if (other.CompareTag("Player"))
            {
                m_Renderer.materials[1].color = Color.red;
                StartCoroutine(ReturnColor());
            }
        }

        IEnumerator ReturnColor()
        {
            _audiSource.Play();
            yield return new WaitForSeconds(1f);
            m_Renderer.materials[1].color = Color.white;
        }
    }
}