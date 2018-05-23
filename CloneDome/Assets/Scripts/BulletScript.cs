using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class BulletScript : MonoBehaviour {

  

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player2")
        {
            Destroy(other.gameObject);
        }
    }
}
