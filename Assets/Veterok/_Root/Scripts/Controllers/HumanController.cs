using System.Linq;
using UnityEngine;
using Veterok.Views;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Veterok.Controllers
{
    public class HumanController : MonoBehaviour
    {
        [SerializeField] private List<HumanView> _humanPrefabs;
        [SerializeField] private int _capacityPool;
        [SerializeField] private float _timeToNextSpawn;
        [SerializeField] private List<Transform> _leftWayPoints;
        [SerializeField] private List<Transform> _rightWayPoints;
        [SerializeField] private List<Transform> _leftSpawnPoints;
        [SerializeField] private List<Transform> _rightSpawnPoints;

        [SerializeField] private float _destinationReachedThreshold;

        private HumanPool _humanPool;
        private float _firstSpawn = 0;

        [SerializeField] private List<HumanView> _spawnedHumans;

        private void Start()
        {
            _spawnedHumans = new List<HumanView>();
            _humanPool = new HumanPool(_humanPrefabs, _capacityPool, transform);
        }

        private void Update()
        {
            _firstSpawn += Time.deltaTime;
            if (_firstSpawn >= _timeToNextSpawn)
            {
                SpawnHuman();
            }

            foreach (var human in _spawnedHumans.ToList())
            {
                if (CheckDestinationReached(human))
                {
                    human.NavAgent.isStopped = true;
                    human.FadeOut();
                }
            }
        }

        private void SpawnHuman()
        {
            var random1 = Random.Range(0, 2);
            switch (random1)
            {
                case 0: InstantiateHuman(_leftSpawnPoints, _rightWayPoints);
                    break;
                case 1: InstantiateHuman(_rightSpawnPoints, _leftWayPoints);
                    break;
            }

            _firstSpawn = 0;
        }

        private void InstantiateHuman(List<Transform> spawnPoints, List<Transform> waypoints)
        {
            var rnd = Random.Range(0, spawnPoints.Count);
            var human = _humanPool.GetHuman();
            human.transform.position = spawnPoints[rnd].position;
            human.HumanFadeOut += ReturnToPool;
            
            var rnd2 = Random.Range(0, waypoints.Count);
            human.SetWayPoint(waypoints[rnd2].position);
            human.NavAgent.isStopped = false;
            _spawnedHumans.Add(human);
        }

        private void ReturnToPool(HumanView human)
        {
            human.HumanFadeOut -= ReturnToPool;
            _humanPool.ReturnToPool(human);
        }

        private bool CheckDestinationReached(HumanView agent)
        {
            var distanceToTarget = Vector3.Distance(agent.transform.position, agent.NavAgent.destination);
            return distanceToTarget < _destinationReachedThreshold;
        }
    }

    internal class HumanPool
    {
        private int _capacityPool;
        private List<HumanView> _humanViews;
        private Stack<HumanView> _humanPool;
        private Transform _rootPool;

        internal HumanPool(List<HumanView> humanViews, int capacityPool, Transform root)
        {
            _humanViews = humanViews;
            _capacityPool = capacityPool;
            _rootPool = root;
            _humanPool = new Stack<HumanView>();
        }
        
        public HumanView GetHuman()
        {
            HumanView human;

            if (_humanPool.Count == 0)
            {
                for (var i = 0; i <= _capacityPool; i++)
                {
                    human = UnityEngine.Object.Instantiate(_humanViews[Random.Range(0, _humanViews.Count)]);
                    ReturnToPool(human);
                }
            }

            human = _humanPool.Pop();
            human.gameObject.SetActive(true);
            human.transform.SetParent(null);
            return human;
        }

        public void ReturnToPool(HumanView human)
        {
            human.transform.SetParent(_rootPool);
            human.transform.localPosition = Vector3.zero;
            _humanPool.Push(human);
            human.gameObject.SetActive(false);
        }
    }
}