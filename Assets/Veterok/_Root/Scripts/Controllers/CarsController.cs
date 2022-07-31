using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Veterok.Pools;
using Veterok.Views;

namespace Veterok.Controllers
{
    public sealed class CarsController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _timeToNextSpawn;
        [SerializeField] private float _destinationReachedThreshold;
        [Space]
        [Header("Attachements")]
        [SerializeField] private List<CarView> _carPrefabs;
        [SerializeField] private Transform _leftSpawnPoint;
        [SerializeField] private Transform _rightSpawnPoint;
        [SerializeField] private Transform _leftWayPoint;
        [SerializeField] private Transform _rightWayPoint;
        
        private float _firstSpawn = 0;
        private CarPool<CarView> _leftSideCarPool;
        private CarPool<CarView> _rightSideCarPool;
        
        private HashSet<CarView> _spawnedCars;

        private void Start()
        {
            _leftSideCarPool = new CarPool<CarView>(10, this.transform, _carPrefabs);
            _rightSideCarPool = new CarPool<CarView>(10, this.transform, _carPrefabs);
        }

        private void Update()
        {

            _firstSpawn += Time.deltaTime;
            if (_firstSpawn >= _timeToNextSpawn)
            {
                SpawnCar();
            }

            foreach (var car in _spawnedCars.ToHashSet())
            {
                if (CheckDestinationReached(car))
                {
                    
                }
            }
        }

        private void SpawnCar()
        {
            
        }

        private void OnDestroy()
        {
            _spawnedCars.Clear();
        }
        
        private bool CheckDestinationReached(CarView car)
        {
            var distanceToTarget = Vector3.Distance(car.transform.position, car.Target.position);
            return distanceToTarget <= _destinationReachedThreshold;
        }
        
        private void ReturnToPool(CarView carView)
        {
            throw new NotImplementedException();
        }
    }
}