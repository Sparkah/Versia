using UnityEngine;

namespace Trudogolik
{
    public class BoxBeepSoundSystem : MonoBehaviour
    {
        public int currentBoxNumber = -1;
        private AudioSource audio;
        [SerializeField] AudioClip[] beepSounds;
        [SerializeField] AudioClip errorSound;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public int GetNumberToBox()
        {
            currentBoxNumber += 1;
            if (currentBoxNumber >= beepSounds.Length)
            {
                currentBoxNumber = 0;
            }
            return currentBoxNumber;
        }

        public void PlayCurrentSound(int i)
        {
            if (beepSounds[i] != null)
                audio.PlayOneShot(beepSounds[i]);
        }
        public void PlayErrorSound()
        {
            if (errorSound != null)
                audio.PlayOneShot(errorSound);
        }

    }
}