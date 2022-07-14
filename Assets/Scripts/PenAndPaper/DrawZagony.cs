using UnityEngine;

namespace Trudogolik
{
    public class DrawZagony : MonoBehaviour
    {
        [SerializeField] private Paper paper;
        public void OnDrawingEnd()
        {
            paper.FinishDraw();
        }
    }
}
