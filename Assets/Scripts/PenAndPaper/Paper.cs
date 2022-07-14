using DG.Tweening;
using UnityEngine;
using OculusSampleFramework;

namespace Trudogolik
{
    public class Paper : MonoBehaviour
    {
        public bool isEmpty = true;
        private SkinnedMeshRenderer skinnedMesh;
        private BoxCollider paperCollider;
        [SerializeField] GameObject newCollider;
        private Rigidbody rb;
        [SerializeField] private GameObject drawing;
        [SerializeField]private Animator animator;
        private Tween drawTween;
        private DistanceGrabbable distanceGrabbable;
        public PaperSpawner paperSpawner;
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
            int animationNumber = Random.Range(0, 2); //поправить под количество анимаций
            animator.SetInteger("animationNumb", animationNumber);
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

            rb.isKinematic = false;
            rb.useGravity = true;

            if (paperSpawner != null)
            {
                Debug.Log("spawned paper");
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



        //temp. можно включить дл€ проверки работы
        //private void OnTriggerExit(Collider other)
        //{

        //    if (other.gameObject.CompareTag("Pen") && !isEmpty)
        //    {
        //        Debug.Log("collided");
        //        CrumplePaper();
        //    }
        //}
    }
}
