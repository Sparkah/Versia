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
        [SerializeField]private Animator animator;
        private Tween drawTween;
        private DistanceGrabbable distanceGrabbable;
        public PaperSpawner paperSpawner;
        private bool isCrumpled = false;

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
            drawing.SetActive(true); //������ �������� ������ � ����������, �� ������� �������� ������������� �������� ���������
            int animationNumber = Random.Range(0, 2); //��������� ��� ���������� ��������
            animator.SetInteger("animationNumb", animationNumber);
        }

        //���������� �� ������� DrawZagony  �� ������ � ����� �������� ���������
        public void FinishDraw()
        {
            

            //�������� 
            //distanceGrabbable.enabled = true;
        }
        public void SetPaperSpawner(PaperSpawner spawner)
        {
            paperSpawner = spawner;
        }

        public void CrumplePaper() //�����������, ����� ����� ������� �� ����� � ������������ ��������
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
        private void AfterCrumple() //����������� � ����� �����
        {
            paperCollider.enabled = false;
            crumplePaperCollider.enabled = true;
        }



        //temp
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
