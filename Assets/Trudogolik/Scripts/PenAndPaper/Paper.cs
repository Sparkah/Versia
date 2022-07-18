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
            drawing.SetActive(true); //������ �������� ������ � ����������, �� ������� �������� ������������� �������� ���������
            animator.SetInteger("animationNumb", animationNumber); //������������� ��������, ������� �������� ����� PaperSpawner
            if(drawSound != null)
            {
                audioSource.PlayOneShot(drawSound);
            }
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
        private void AfterCrumple() //����������� � ����� �����
        {
            paperCollider.enabled = false;
            newCollider.SetActive(true);
        }


        //temp.����� �������� ��� �������� ������
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
