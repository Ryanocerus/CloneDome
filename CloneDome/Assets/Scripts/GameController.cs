using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

//The name of the script and where the script gets its information from.
public class GameController : MonoBehaviour
{
    // Update ()
    // Called every frame
    // Return:
    //     Void
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
