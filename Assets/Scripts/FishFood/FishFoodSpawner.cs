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

    [SerializeField] private int _capacityPool;
    [SerializeField] private List<GameObject> _spawnedFishFood = new List<GameObject>();
    //spawn 50 particle, object pool after
    
    private float maxUp;
    private float maxBottom;
    private float percent;
    private float gap;
    private float currentTime = 0f;

    private int maxFishFood = 40;
    private int newlySpawnedFishFood = 0;
    private int currentFishFood =0;
    



    void Awake()
    {
        maxUp = up.position.y;
        maxBottom = bottom.position.y;
        percent = (maxUp - maxBottom) / 100;
    }

    void Update()
    {
        var differenece = (up.position.y - bottom.position.y) / percent * -1;
        Debug.Log(_spawnedFishFood.ToArray().Length);
        if (differenece > 5)
        {
            currentTime += Time.deltaTime;
            gap = DetermineGap(differenece);

            if (currentTime > gap)
            {
                //var human = _FishFoodPool.GetHuman();
                if (newlySpawnedFishFood < maxFishFood)
                {
                    var food = Instantiate(fishFood, up.position, Quaternion.identity);
                    _spawnedFishFood.Add(food);
                    newlySpawnedFishFood += 1;
                }
                else if(currentFishFood<maxFishFood)
                {
                    _spawnedFishFood[currentFishFood].transform.position = up.position;
                    currentFishFood += 1;
                }
                else
                {
                    currentFishFood = 0;
                }

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