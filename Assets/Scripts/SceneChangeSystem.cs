using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChangeSystem
{
    private static string[] _scenes = new string[] { "Scene_1", "Scene_2", "Scene_3", "Scene_4"};
    public static int current = 0;

    public static void NextScene()
    {
        current += 1;
        SceneManager.LoadScene(_scenes[current]);
    }
}