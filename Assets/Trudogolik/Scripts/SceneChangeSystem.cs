using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trudogolik
{
    public static class SceneChangeSystem
    {
        private static string[] _scenes = new string[] { "Scene_1", "Scene_2", "Scene_3", "Scene_4", "Scene_5" };
        public static int current = 0;

        //����� ����������� ����������� ���������, ��� ��������� � ������� ������ � ��������� ����� ����� �������
        //! �� ������ ����� ������� ����� ���� �������� � ��������� �� ��������� ������ ����� Reset()
        public static bool FishFed = true; 

        public static void NextScene()
        {

            current += 1;
            SceneManager.LoadScene(_scenes[current]);
        }

        public static void ResetValues()
        {
            FishFed = true;
        }
    }
}