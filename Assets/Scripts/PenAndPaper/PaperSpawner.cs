using UnityEngine;

namespace Trudogolik
{
    public class PaperSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject paperPrefab;
        [SerializeField] private Transform spawnPosition;

        private void Start()
        {
            SpawnPaper();
        }

        public void SpawnPaper()
        {
            var newPaper = Instantiate(paperPrefab, spawnPosition.position, Quaternion.identity );
            newPaper.transform.parent = null;
            var val = Random.Range(-8f, 8f);
            newPaper.transform.Rotate(new Vector3(0,val,0), Space.Self);
            newPaper.GetComponent<Paper>().SetPaperSpawner(this);
        }
    }
}
