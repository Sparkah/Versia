using UnityEngine;

public class FishFoodLifetime : MonoBehaviour
{
   private float _lifetime;

   private float _currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        _lifetime = Random.Range(1f, 4f);
        //Debug.Log("lifetime " +_lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _lifetime)
        {
            Destroy(gameObject);
            //_humanPool.ReturnToPool(human);
            //gameObject.SetActive(false);
        }
    }
}
