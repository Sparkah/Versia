using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class ExitScript : MonoBehaviour
    {
        [SerializeField] private GameObject[] gameObjects;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
        }

        public void CallAndEnableExit()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(true);
            }
            audioSource.Play();
        }
    }
}