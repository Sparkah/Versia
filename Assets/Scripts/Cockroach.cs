using UnityEngine;

public class Cockroach : MonoBehaviour
{
    private Animation anim;
    [SerializeField] private GameObject cockroach;
    [SerializeField] private GameObject deadCockroach;
    // private float currentTime = 0f;
    // private float maxTime = 3f;
    // private bool isKilled;

    private void Awake()
    {
        deadCockroach.SetActive(false);
        anim = GetComponent<Animation>();
    }


    // void Update()
    // {
    //     currentTime += Time.deltaTime;
    //     if (currentTime >= maxTime && !isKilled)
    //     {
    //         KillCockroach();
    //         isKilled = true;
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            KillCockroach();
        }
    }

    public void KillCockroach()
    {
        deadCockroach.transform.position = cockroach.transform.position;
        deadCockroach.SetActive(true);
        anim.enabled = false;
        cockroach.SetActive(false);
    }
}
