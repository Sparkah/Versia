using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Veterok.Interfaces;
using Veterok.Pools;
using Veterok.Views;

namespace Veterok.Controllers
{
    public class ParticlesSpawner: IObserver, IDisposable
    {
        private HashSet<SwirlParticleView> _spawnedParticles;
        
        private float _startScan;
        private float _scanRate = 0.3f;
        
        private ParticlePool<SwirlParticleView> _swirlPool;

        internal ParticlesSpawner(int capacityPool, Transform root, SwirlParticleView view)
        {
            _swirlPool = new ParticlePool<SwirlParticleView>(capacityPool, root, view);
            _spawnedParticles = new HashSet<SwirlParticleView>();
        }

        public void UpdateParticles(float deltaTime)
        {
            _startScan += deltaTime;
            if (_startScan < _scanRate) return;
            ProcessParticles();
        }

        private void ProcessParticles()
        {
            foreach (var particle in _spawnedParticles.ToHashSet())
            {
                if(particle.GetComponent<ParticleSystem>().isStopped)
                    _swirlPool.ReturnToPool(particle);
            }
            _startScan = 0;
        }
        
        public void Update(GameObject obj)
        {
            if (obj.GetComponent<PacketView>().IsDead) return;
            
            var particle = _swirlPool.GetObject();
            particle.transform.position = obj.transform.position;
            _spawnedParticles.Add(particle);
        }
        
        public void Dispose()
        {
            _spawnedParticles.Clear();
        }
    }
}