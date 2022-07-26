using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class FishFoodSpawner : MonoBehaviour
    {
        [SerializeField] private Transform bottom;
        [SerializeField] private Transform up;
        [SerializeField] private GameObject fishFood;
        [Space]
        [SerializeField] private float ScareFadeSpeed = 1f;
        [Space]
        public float val1 = 1f;
        public float val2 = 0.5f;
        public float val3 = 0.1f;

        [SerializeField] private int _capacityPool;
        [SerializeField] private List<GameObject> _spawnedFishFood = new List<GameObject>();

        private float maxUp;
        private float maxBottom;
        private float percent;
        private float gap;
        private float currentTime = 0f;

        private int maxFishFood = 40;
        private int newlySpawnedFishFood = 0;
        private int currentFishFood = 0;

        void Awake()
        {
            maxUp = up.position.y;
            maxBottom = bottom.position.y;
            percent = (maxUp - maxBottom) / 100;
        }

        void Update()
        {
            var differenece = (up.position.y - bottom.position.y) / percent * -1;
            //Debug.Log(_spawnedFishFood.ToArray().Length);
            if (differenece > 5)
            {
                currentTime += Time.deltaTime;
                gap = DetermineGap(differenece);

                CheckFishFoodLifetimePool();
                CanvasManager.Instance.SetScareFadeSpeed(ScareFadeSpeed);
            }
            else
            {
                currentTime = 0;
            }
        }

        private void CheckFishFoodLifetimePool()
        {
            if (currentTime > gap)
            {
                if (newlySpawnedFishFood < maxFishFood)
                {
                    var food = Instantiate(fishFood, up.position, Quaternion.identity);
                    _spawnedFishFood.Add(food);
                    newlySpawnedFishFood += 1;
                    StartCoroutine(DeactivateFishFood(food));
                }
                else if (currentFishFood < maxFishFood)
                {
                    _spawnedFishFood[currentFishFood].SetActive(true);
                    _spawnedFishFood[currentFishFood].transform.position = up.position;
                    currentFishFood += 1;
                    StartCoroutine(DeactivateFishFood(_spawnedFishFood[currentFishFood].gameObject));
                }
                else
                {
                    currentFishFood = 0;
                }

                currentTime = 0;
            }
        }

        private IEnumerator DeactivateFishFood(GameObject food)
        {
            yield return new WaitForSeconds(2f);
            food.SetActive(false);
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
}