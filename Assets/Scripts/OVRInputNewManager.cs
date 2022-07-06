using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OVRInputNewManager : MonoBehaviour
{
    void LateStart()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    /*
     One                       = 0x00000001, ///< Maps to RawButton: [Gamepad, Touch, RTouch: A], [LTouch: X], [Remote: Start]
		Two                       = 0x00000002, ///< Maps to RawButton: [Gamepad, Touch, RTouch: B], [LTouch: Y], [Remote: Back]
		Three                     = 0x00000004, ///< Maps to RawButton: [Gamepad, Touch: X], [LTouch, RTouch, Remote: None]
		Four                      = 0x00000008, ///< Maps to RawButton: [Gamepad, Touch: Y], [LTouch, RTouch, Remote: None]
    */
}
