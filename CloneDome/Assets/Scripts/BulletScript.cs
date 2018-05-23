using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject bulletSpawner;

    public float bulletSpeed = 20;

    public GameObject bulletPrefab;

    public Transform bulletSpawnPoint;

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject GO = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce(bulletSpawner.transform.forward * bulletSpeed, ForceMode.Impulse);
        }
	}
}
