using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform bottom;
    [SerializeField] private Transform up;
    [SerializeField] private GameObject fishFood;
    public float val1 = 1f;
    public float val2 = 0.5f;
    public float val3 = 0.1f;
    
    //fishfood object pool
    //[SerializeField] private List<GameObject> _fishFoodPrefabs;
    [SerializeField] private int _capacityPool;
    private FishFoodPool _FishFoodPool;
    [SerializeField] private List<GameObject> _spawnedFishFood;
    
    private float maxUp;
    private float maxBottom;
    private float percent;
    private float gap;
    private float currentTime = 0f;



    void Awake()
    {
        maxUp = up.position.y;
        maxBottom = bottom.position.y;
        percent = (maxUp - maxBottom) / 100;
    }

    private void Start()
    {
        _FishFoodPool = new FishFoodPool(fishFood, _capacityPool, up);
    }


    void Update()
    {
        var differenece = (up.position.y - bottom.position.y) / percent * -1;

        if (differenece > 5)
        {
            currentTime += Time.deltaTime;
            gap = DetermineGap(differenece);

            if (currentTime > gap)
            {
                //var human = _FishFoodPool.GetHuman();
                Instantiate(fishFood, up.position, Quaternion.identity);
                currentTime = 0;
               // Debug.Log("fishfood");
            }
        }
        else
        {
            currentTime = 0;
        }
    }

    private float DetermineGap(float val)
    {
        if (val > 5 && val <= 33)
        {
            return val1;
        }

        if (val > 33 && val <= 66)
        {
            return val2;
        }

        if (val > 66 && val <= 100)
        {
            return val3;
        }
        return 0;
    }


}

internal class FishFoodPool
{
    private int _capacityPool;
    private GameObject _humanViews;
    private Stack<GameObject> _humanPool;
    private Transform _rootPool;

    internal FishFoodPool(GameObject humanViews, int capacityPool, Transform root)
    {
        _humanViews = humanViews;
        _capacityPool = capacityPool;
        _rootPool = root;
        _humanPool = new Stack<GameObject>();
    }

    public GameObject GetHuman()
    {
        GameObject human;

        if (_humanPool.Count == 0)
        {
            for (var i = 0; i <= _capacityPool; i++)
            {
                human = UnityEngine.Object.Instantiate(_humanViews);
                ReturnToPool(human);
            }
        }

        human = _humanPool.Pop();
        human.gameObject.SetActive(true);
        human.transform.SetParent(null);
        return human;
    }

    public void ReturnToPool(GameObject fishFood)
    {
        fishFood.transform.SetParent(_rootPool);
        fishFood.transform.localPosition = Vector3.zero;
        _humanPool.Push(fishFood);
        fishFood.gameObject.SetActive(false);
    }
}