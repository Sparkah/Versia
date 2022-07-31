using DG.Tweening;
using UnityEngine;
using OculusSampleFramework;
using ObjectOutline;

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

        [SerializeField] private float impulseForce = 0f;
        [SerializeField] private float impulseSpeed = 0f;

        private DistanceGrabbable distanceGrabbable;
        private PaperSpawner paperSpawner;
        private SkinnedMeshRenderer skinnedMesh;
        private SphereCollider paperCollider;
        private BoxCollider paperCollide2;
        private Rigidbody rb;
        private Tween drawTween;
        public int animationNumber = 0;
        [SerializeField] private GameObject crumpledPaper;

        public bool isEmpty = true;
        private bool isCrumpled = false;

        private void Start()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            paperCollider = GetComponent<SphereCollider>();
            paperCollide2 = GetComponent<BoxCollider>();
            rb = GetComponent<Rigidbody>(); 
            drawing.SetActive(false);
            distanceGrabbable = GetComponent<DistanceGrabbable>();
            distanceGrabbable.enabled = false;
            newCollider.SetActive(true);
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pen") && isEmpty && other.gameObject.GetComponent<Pen>().isPenActive)
            {
                isEmpty = false;
                
                DrawPicture();
                CanvasManager.Instance.MakeImpulseScareFade(impulseForce, impulseSpeed);
                
            }

            if (other.CompareTag("Player") && isEmpty ==false)
            {
                CrumplePaper();
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
            distanceGrabbable.enabled = true;
            GameObject outlineView = GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
            outlineView.AddComponent<Outline>();
            outlineView.GetComponent<Outline>().OutlineColor = new Color(185,255,255);
            outlineView.GetComponent<Outline>().OutlineWidth = 10;
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
            paperCollider.enabled = true;
            paperCollide2.enabled = true;
            newCollider.SetActive(false);
            distanceGrabbable.enabled = true;
            Instantiate(crumpledPaper, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
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
