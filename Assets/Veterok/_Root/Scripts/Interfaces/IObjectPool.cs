using System.Collections.Generic;
using UnityEngine;

namespace Veterok.Interfaces
{
    public interface IObjectPool<T>
    {
        public int PoolCapacity { get; }
        public Transform Root { get; }
        public Stack<T> ObjectPool { get; }
        public abstract T GetObject();
        public void ReturnToPool(T obj);
    }
}