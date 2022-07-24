using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pigeon;
using Trudogolik;
using UnityEngine.SceneManagement;

public static class SceneLoaderHubMain 
{
    public static void LoadPigeonGame()
    {
        SceneManager.LoadScene("GolubNaUgin");
    }

    public static void LoadTrudogolikGame()
    {
        SceneManager.LoadScene("Scene_1");
    }

    public static void LoadVeterokGame()
    {
        //SceneManager.LoadScene("Veterok?");
    }
}