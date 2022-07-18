using DG.Tweening;
using UnityEngine;
using OculusSampleFramework;

namespace Trudogolik
{
    public class Paper : MonoBehaviour
    {
        [SerializeField] GameObject newCollider;
        [SerializeField] private GameObject drawing;
        [SerializeField] private Animator animator;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip drawSound;
        [SerializeField] private AudioClip crumbleSound;

        private DistanceGrabbable distanceGrabbable;
        private PaperSpawner paperSpawner;
        private SkinnedMeshRenderer skinnedMesh;
        private BoxCollider paperCollider;
        private Rigidbody rb;
        private Tween drawTween;
        public int animationNumber = 0;

        public bool isEmpty = true;
        private bool isCrumpled = false;

        private void Start()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            paperCollider = GetComponent<BoxCollider>();
            rb = GetComponent<Rigidbody>(); 
            drawing.SetActive(false);
            distanceGrabbable = GetComponent<DistanceGrabbable>();
            distanceGrabbable.enabled = false;
            newCollider.SetActive(false);
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pen") && isEmpty && other.gameObject.GetComponent<Pen>().isPenActive)
            {
                isEmpty = false;
                
                DrawPicture();
                
            }
        }

        private void DrawPicture()
        {
            drawing.SetActive(true); //делает активным объект с аниматором, на котором начинает проигрыватьс€ анимаци€ рисовани€
            animator.SetInteger("animationNumb", animationNumber); //устанавливаем анимацию, которую задавали через PaperSpawner
            if(drawSound != null)
            {
                audioSource.PlayOneShot(drawSound);
            }
        }

        //вызываетс€ из скрипта DrawZagony  по ивенту в конце анимации рисовани€
        public void FinishDraw()
        {
            //¬ Ћё„»“№ 
            //distanceGrabbable.enabled = true;
        }
        public void SetPaperSpawner(PaperSpawner spawner)
        {
            paperSpawner = spawner;
        }

        public void CrumplePaper() //запускаетс€, когда игрок кликает по листу с нарисованным рисунком
        {
            if (isCrumpled)
                return;
            isCrumpled = true;

            if (crumbleSound != null)
            {
                audioSource.PlayOneShot(crumbleSound);
            }

            rb.isKinematic = false;
            rb.useGravity = true;

            if (paperSpawner != null)
            {
                //Debug.Log("spawned paper");
                paperSpawner.SpawnPaper();
            }
            
            drawing.SetActive(false);
            drawTween = DOTween.To(() => skinnedMesh.GetBlendShapeWeight(0), x => skinnedMesh.SetBlendShapeWeight(0, x), 100f, 0.1f).OnComplete(() => AfterCrumple());
        }
        private void AfterCrumple() //запускаетс€ в конце твина
        {
            paperCollider.enabled = false;
            newCollider.SetActive(true);
        }


        //temp.можно включить дл€ проверки работы
        //private void OnTriggerExit(Collider other)
        //{

        //    if (other.gameObject.CompareTag("Pen") && !isEmpty)
        //    {
        //        //Debug.Log("collided");
        //        CrumplePaper();
        //    }
        //}
    }
}
