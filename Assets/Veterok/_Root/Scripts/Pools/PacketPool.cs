using System.Collections.Generic;
using UnityEngine;
using Veterok.Views;

namespace Veterok.Pools
{
    internal class PacketPool<T> : PoolBase<T> where T : PacketView
    {
        private T _packetView;
        private List<T> _spawnedObjects;

        public PacketPool(int poolCapacity, Transform root, T packetView) : base(poolCapacity, root)
        {
            _packetView = packetView;
        }
        
        public override T GetObject()
        {
            T obj;

            if (ObjectPool.Count == 0)
            {
                for (var i = 0; i <= PoolCapacity; i++)
                {
                    obj = Object.Instantiate(_packetView);
                    ReturnToPool(obj);
                }
            }

            obj = ObjectPool.Pop();
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(null);
            return obj;
        }

        public override void ReturnToPool(T obj)
        {
            obj.transform.SetParent(Root);
            obj.transform.localPosition = Vector3.zero;
            ObjectPool.Push(obj);
            obj.gameObject.SetActive(false);
        }
    }
}