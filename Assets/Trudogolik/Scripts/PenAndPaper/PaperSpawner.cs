using UnityEngine;

namespace Trudogolik
{
    public class PaperSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject paperPrefab;
        [SerializeField] private Transform spawnPosition;
        private int currentDraw = -1;
        private int maxDraw = 5;

        private void Start()
        {
            SpawnPaper();
        }

        public void SpawnPaper()
        {
            currentDraw++;
            if (currentDraw > maxDraw)
                currentDraw = 0;

            var newPaper = Instantiate(paperPrefab, spawnPosition.position, Quaternion.identity);
            newPaper.transform.parent = null;
            var RandomPaperRotation = Random.Range(-8f, 8f);
            newPaper.transform.Rotate(new Vector3(0, RandomPaperRotation, 0), Space.Self);
            var paper = newPaper.GetComponent<Paper>();
            paper.SetPaperSpawner(this); //чтобы не использовать синглтон
            paper.animationNumber = currentDraw;
        }
    }
}
