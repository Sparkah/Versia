using UnityEngine;
using UnityEngine.Playables;

namespace Trudogolik

{
    public class FinalLauncher : MonoBehaviour
    {
        private PlayableDirector pDirector;
        void Start()
        {
            pDirector = GetComponent<PlayableDirector>();
        }

        public void StartTimeline()
        {
            pDirector.Play();
        }
    }
}