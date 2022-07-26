using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trudogolik
{
    public static class SceneChangeSystem
    {
        private static string[] _scenes = new string[] { "Scene_1", "Scene_2", "Scene_3", "Scene_4", "Scene_5", "Scene_6", "Scene_7", "Scene_8", "Scene_9", };
        public static int current = 0;

        //Здесь перечисляем статические переменые, при обращении к которым меняем в менеджере самой сцены объекты
        //! на первой сцене сделать ресет всех значений к значениям по умолчанию вызвав метод Reset()
        public static bool FishFed = false; 

        public static void NextScene()
        {
            if(SceneManager.GetActiveScene().name=="Scene_9")
            {
                ResetValues();
                SceneLoaderHubMain.LoadHubMenu();
                return;
            }
            current += 1;
            SceneManager.LoadScene(_scenes[current]);
        }

        public static void ResetValues()
        {
            FishFed = false;
        }
    }
}