using UnityEngine;

namespace Trudogolik
{
    public class Cockroach : MonoBehaviour
    {
        private Animation anim;
        [SerializeField] private GameObject cockroach;
        [SerializeField] private GameObject deadCockroach;

        private void Awake()
        {
            deadCockroach.SetActive(false);
            anim = GetComponentInParent<Animation>();
        }

        private bool isDead = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isDead == false)
            {
                KillCockroach();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && isDead == false)
            {
                KillCockroach();
            }
        }

        public void KillCockroach()
        {
            deadCockroach.transform.position = cockroach.transform.position;
            deadCockroach.SetActive(true);
            anim.enabled = false;
            cockroach.SetActive(false);
            isDead = true;
        }
    }
}