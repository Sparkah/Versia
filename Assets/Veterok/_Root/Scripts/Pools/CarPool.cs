using System.Collections.Generic;
using UnityEngine;
using Veterok.Views;

namespace Veterok.Pools
{
    internal class CarPool<T> : PoolBase<T> where T : CarView
    {
        private List<CarView> _carViews;
        
        public CarPool(int poolCapacity, Transform root, List<CarView> carViews) : base(poolCapacity, root)
        {
            _carViews = carViews;
        }

        public override T GetObject()
        {
            T obj;

            if (ObjectPool.Count == 0)
            {
                for (var i = 0; i <= PoolCapacity; i++)
                {
                    obj = Object.Instantiate(_carViews[Random.Range(0, _carViews.Count)]) as T;
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