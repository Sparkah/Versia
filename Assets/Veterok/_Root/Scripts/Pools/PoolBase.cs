using System;
using UnityEngine;
using Veterok.Interfaces;
using System.Collections.Generic;

namespace Veterok.Pools
{
    public abstract class PoolBase<T> : IObjectPool<T>, IDisposable
    {
        public int PoolCapacity { get; }
        public Transform Root { get; }
        public Stack<T> ObjectPool { get; }

        public PoolBase(int poolCapacity, Transform root)
        {
            PoolCapacity = poolCapacity;
            Root = root;
            ObjectPool = new Stack<T>();
        }

        public abstract T GetObject();

        public abstract void ReturnToPool(T obj);

        public virtual void Dispose()
        {
            ObjectPool.Clear();
        }
    }
}