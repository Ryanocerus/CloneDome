using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

//The name of the script and where the script gets its information from.
public class BulletScriptP1 : MonoBehaviour
{
    // OnCollisionEnter ()
    // Called every frame
    // Param:
    // Collision other -  the collision of this gameobject. In this case, the other player’s collider.
    // Return:
    //     Void
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player2")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player3")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player4")
        {
            Destroy(other.gameObject);
        }
    }

    // Start ()
    // Called on intialization
    // Return:
    //     Void
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

}
