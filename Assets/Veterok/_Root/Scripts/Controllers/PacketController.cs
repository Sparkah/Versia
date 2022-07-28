using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Veterok.Interfaces;
using Veterok.Pools;
using Veterok.Views;
using Random = UnityEngine.Random;


namespace Veterok.Controllers
{
    public class PacketController : MonoBehaviour
    {
        public event Action<int> RisedPackets;
        
        [Header("Prefabs")]
        [SerializeField] private PacketView _packetView;
        [SerializeField] private AngelView _angelPrefab;
        [SerializeField] private SwirlParticleView _swirlView;
        [Space]
        [Header("Parameters")]
        private float _firstSpawn = 0;
        private float _firstDequeue = 0;
        [SerializeField] private float _windForce;
        [SerializeField] private float _timeToNextSpawn;
        [SerializeField] private float _timeToDequeue;
        private PacketPool<PacketView> _packetPool;
        [Space]
        [Header("Spawn info")] 
        private Queue<PacketView> _packetsInWind;
        private ParticlesSpawner _particlesSpawner;
        [SerializeField] private int _capacityParticlePool;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private List<PacketView> _spawnedPackets;
        [SerializeField] private List<AngelView> _angels;

        private float _firstScanTime = 0;
        private float _timeToNextScan = 0.3f;

        private int _packetRiseCounter;       
        public int PacketsCounter
        {
            get => _packetRiseCounter;
            private set
            {
                _packetRiseCounter = value;
                RisedPackets?.Invoke(_packetRiseCounter);
            }
        }

        [SerializeField][Range(2f, 20f)] private float _destructionHeight;
        public void Start()
        {
            _packetRiseCounter = 0;
            _angels = new List<AngelView>();
            _packetsInWind = new Queue<PacketView>();
            _packetPool = new PacketPool<PacketView>(10, transform, _packetView);
            _particlesSpawner = new ParticlesSpawner(_capacityParticlePool, transform, _swirlView);
        }
        
        private void Update()
        {
            var time = Time.deltaTime;
            _firstScanTime += time;
            _firstSpawn += time;
            _firstDequeue += time;

            _particlesSpawner.UpdateParticles(Time.deltaTime);
            
            if (_firstScanTime >= _timeToNextScan)
            {
                if (_spawnedPackets.Count != 0)
                {
                    foreach (var packet in _spawnedPackets.ToList())
                    {
                        if(packet.transform.position.y >= _destructionHeight)
                            packet.FadeOut();
                    }
                }

                foreach (var angel in _angels.ToList())
                {
                    
                    if (angel.Particle.isStopped)
                    {
                        DestroyAngel(angel);
                    }
                }

                _firstScanTime = 0;
            }

            if (_firstSpawn >= _timeToNextSpawn)
            {
                SpawnPacket();
            }

            foreach (var packet in _spawnedPackets.ToList())
            {
                if (packet.IsDead)
                    _spawnedPackets.Remove(packet);
            }
            
            
            if (!(_firstDequeue >= _timeToDequeue)) return;
            if (_packetsInWind.Count == 0) return;
                RemovePacketFromWind();
        }

        private void FixedUpdate()
        {
            foreach (var packet in _packetsInWind.ToHashSet())
            {
                var force = _windForce * Time.deltaTime;
                packet.AddLinearForce(force);
            }
        }

        private void  RemovePacketFromWind()
        {
            _packetsInWind.Dequeue();
            //packeto.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Debug.Log(_packetsInWind.Count);
            _firstDequeue = 0;
        }

        private void SpawnPacket()
        {
            var packetView = _packetPool.GetObject();
            packetView.PacketFadeOut += DestroyPacket;
            packetView.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position;
            packetView.transform.rotation = Quaternion.identity;
            if (packetView is IObservable packet)
            {
                packet.AddObserver(_particlesSpawner);
            }
            _spawnedPackets.Add(packetView);
            _packetsInWind.Enqueue(packetView);
            _firstSpawn = 0;
        }
        
        private void DestroyPacket(PacketView packet)
        {
            PacketsCounter += 1;
            packet.PacketFadeOut -= DestroyPacket;
            var angel = Instantiate(_angelPrefab, packet.transform.position, Quaternion.identity);
            _packetPool.ReturnToPool(packet);
            _spawnedPackets.Remove(packet);
            _angels.Add(angel);
        }

        private void DestroyAngel(AngelView obj)
        {
            _angels.Remove(obj);
            Destroy(obj.gameObject);
        }

        public void AddForceToPackets()
        {
            PacketView packet;
            if (_spawnedPackets.Count != 0)
            {
                packet = _spawnedPackets[Random.Range(0, _spawnedPackets.Count)];
                    packet.AddForce();
            }
        }

        private void OnDestroy()
        {
            _spawnedPackets.Clear();
            _packetsInWind.Clear();
            _angels.Clear();
            _packetPool.Dispose();
            _particlesSpawner.Dispose();
        }
    }
}