using UnityEngine;
using Trudogolik;

namespace Trudogolik
{

    public class FishCondition : MonoBehaviour
    {
        [SerializeField] GameObject DeadFish;
        [SerializeField] Animator fishAnimator;
        [SerializeField] GameObject Fish;
        void Start()
        {
            if(SceneChangeSystem.FishFed)
            {
                DeadFish.SetActive(false);
            }
            else
            {
                DeadFish.SetActive(true);
                fishAnimator.StopPlayback();
                Fish.SetActive(false);
            }
        }

        
    }
}