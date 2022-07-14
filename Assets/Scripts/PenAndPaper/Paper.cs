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
        private SphereCollider crumplePaperCollider;
        private Rigidbody rb;
        [SerializeField] private GameObject drawing;
        private Tween drawTween;
        private DistanceGrabbable distanceGrabbable;

        private void Start()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            paperCollider = GetComponent<BoxCollider>();
            crumplePaperCollider = GetComponent<SphereCollider>();
            crumplePaperCollider.enabled = false;
            rb = GetComponent<Rigidbody>(); 
            drawing.SetActive(false);
            distanceGrabbable = GetComponent<DistanceGrabbable>();
            distanceGrabbable.enabled = false;

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
            drawing.SetActive(true); //делает активным объект с аниматором, на котором начинает проигрываться анимация рисования
        }

        //вызывается из скрипта DrawZagony  по ивенту в конце анимации рисования
        public void FinishDraw()
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            distanceGrabbable.enabled = true;
        }



        public void CrumplePaper() //запускается, когда игрок кликает по листу с нарисованным рисунком
        {
            drawing.SetActive(false);
            drawTween = DOTween.To(() => skinnedMesh.GetBlendShapeWeight(0), x => skinnedMesh.SetBlendShapeWeight(0, x), 100f, 0.1f).OnComplete(() => AfterCrumple());
        }
        private void AfterCrumple() //запускается в конце твина
        {
            paperCollider.enabled = false;
            crumplePaperCollider.enabled = true;
        }

        

        //temp
        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Pen") && !isEmpty)
        //    {
        //        CrumplePaper();
        //    }
        //}
    }
}
