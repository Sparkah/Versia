using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHubView : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pigeon"))
        {
            SceneLoaderHubMain.LoadPigeonGame();
        }

        if(other.CompareTag("FishFood"))
        {
            SceneLoaderHubMain.LoadTrudogolikGame();
        }

        if (other.CompareTag("WindZone"))
        {
            SceneLoaderHubMain.LoadVeterokGame();
        }
    }
}