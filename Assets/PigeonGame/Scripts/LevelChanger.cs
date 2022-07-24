using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pigeon
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private FadeInFadeOut _fadeOut;
        [SerializeField] private AudioSource _source;
        private int count = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (count < 1 && other.TryGetComponent(out CharacterController controller))
            {
                StartCoroutine(LoadLevel());
            }
        }

        private IEnumerator LoadLevel()
        {
            _source.Play();
            _fadeOut.FadeIn();
            yield return new WaitForSeconds(2f);
            int level = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(level);
        }

    }
}