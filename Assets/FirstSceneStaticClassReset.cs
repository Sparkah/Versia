using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class FirstSceneStaticClassReset : MonoBehaviour
    {
        void Start()
        {
            SceneChangeSystem.ResetValues();
        }
    }
}