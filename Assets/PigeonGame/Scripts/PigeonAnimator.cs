using UnityEngine;

namespace Pigeon
{
    [RequireComponent(typeof(PigeonController))]
    public class PigeonAnimator : MonoBehaviour
    {
        private PigeonController controller;
        private Animator animator;
        private int _lastState = 0;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            controller = GetComponent<PigeonController>();
        }

        private void Update()
        {
            if (controller.Landed && !animator.GetBool("Landed"))
            {
                Controller_Landed();
            }
            else if (!controller.Landed && animator.GetBool("Landed"))
            {
                Controller_Scared();
            }
        }

        private void Controller_Scared()
        {
            animator.SetTrigger("Scared");
            animator.SetBool("Landed", false);
        }

        private void Controller_Landed()
        {
            animator.SetBool("Landed", true);
        }

        public void NextRandomAnim()
        {
            int r = Random.Range(0, 3);
            while (r == _lastState)
            {
                r = Random.Range(0, 3);
            }
            _lastState = r;
            animator.SetInteger("EatingBlend", r);
        }
    }
}