using UnityEngine;
using Veterok.Views;

namespace Veterok.Pools
{
    public class ParticlePool<T> : PoolBase<T> where T : SwirlParticleView
    {
        private T _particleView;

        public ParticlePool(int poolCapacity, Transform root, T particleView) : base(poolCapacity, root)
        {
            _particleView = particleView;
        }
                
        public override T GetObject()
        {
            T particle;

            if (ObjectPool.Count == 0)
            {
                for (var i = 0; i <= PoolCapacity; i++)
                {
                    particle = Object.Instantiate(_particleView, Root.position, Quaternion.identity);
                    ReturnToPool(particle);
                }
            }
            particle = ObjectPool.Pop();
            particle.gameObject.SetActive(true);
            particle.transform.SetParent(null);
            return particle;
        }

        public override void ReturnToPool(T particle)
        {
            particle.transform.SetParent(Root);
            particle.transform.localPosition = Vector3.zero;
            ObjectPool.Push(particle);
            particle.gameObject.SetActive(false);
        }
    }
}