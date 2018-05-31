using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

//The name of the script and where the script gets its information from.
public class BulletSpawnP1 : MonoBehaviour {
    //Declares variable GameObject as bulletSpawner.
    public GameObject bulletSpawner;
    //Sets bulletSpeed at a base 20.
    public float bulletSpeed = 20;
    //Sets the shootDelay to a base 1.
    public float shootDelay = 1;
    //Declares variable internalShootDelay.
    private float internalShootDelay;
    //Declares variable GameObject bulletPrefab.
    public GameObject bulletPrefab;
    //Declares variable Transform as bulletSpawnPoint.
    public Transform bulletSpawnPoint;
    //Sets the controller to XboxController.
    public XboxController controller;

    // Start ()
    // Called on intialization
    // Return:
    //     Void
    void Start()
    {
        internalShootDelay = shootDelay;
    }

    // Update ()
    // Called every frame
    // Return:
    //     Void
    void Update()
    {
        internalShootDelay -= Time.deltaTime;

		if (internalShootDelay < 0 && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GameObject GO = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * bulletSpeed, ForceMode.Impulse);

            internalShootDelay = shootDelay;
        }
	}


}
