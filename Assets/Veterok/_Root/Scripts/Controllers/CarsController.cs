using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Veterok.Pools;
using Veterok.Views;
using Random = UnityEngine.Random;


namespace Veterok.Controllers
{
    public enum CarType
    {
        None = 0,
        LeftSide = 1,
        RightSide = 2
    }
    
    public sealed class CarsController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _timeToNextSpawn;
        [SerializeField] private float _destinationReachedThreshold = 0.2f;
        [Space]
        [Header("Attachements")]
        [SerializeField] private List<CarView> _carPrefabs;
        [SerializeField] private Transform _leftSpawnPoint;
        [SerializeField] private Transform _rightSpawnPoint;
        [SerializeField] private Transform _leftWayPoint;
        [SerializeField] private Transform _rightWayPoint;

        
        
        private float _firstSpawn = 0;
        private CarPool<CarView> _carPool;

        private HashSet<CarView> _spawnedCars;

        private void Start()
        {
            _firstSpawn = _timeToNextSpawn;
            _spawnedCars = new HashSet<CarView>();
            _carPool = new CarPool<CarView>(10, transform, _carPrefabs);
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
                    ReturnToPool(car);
                }
                car.MoveToTargetPosition(Time.deltaTime);
            }
        }

        private void SpawnCar()
        {
            var rnd = Random.Range(0, 2);
            var car = _carPool.GetObject();
            var carTransform = car.transform;
            switch (rnd)
            {
                case 0: 
                    carTransform.position = _leftSpawnPoint.position;
                    carTransform.rotation = _leftSpawnPoint.rotation;
                    car.SetTarget(_rightWayPoint);
                    break;
                case 1:
                    carTransform.position = _rightSpawnPoint.position;
                    carTransform.rotation = _rightSpawnPoint.rotation;
                    car.SetTarget(_leftWayPoint);
                    break; 
            }
            _spawnedCars.Add(car);
            _firstSpawn = 0;
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
            _carPool.ReturnToPool(carView);
        }
    }
}