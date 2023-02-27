using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    //Projectile Instantiation Variables
    public GameObject projectilePrefab;
    public string triggerButton;
    public string boostButton;
    public Transform spawnPoint;
    public Rigidbody shipRb;

    public float fireRate = 0.15f;
    private float nextFire = 0.0f;   
    public float shootForce = 1700f;

    //Audio Variables
    public AudioSource audioPlayer;
    public AudioClip laserShoot;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        if (!Input.GetButton(boostButton))
        {
            //Right Controller Trigger instantiates laser projectile every x seconds
            if (Input.GetButton(triggerButton) && Time.time > nextFire)
            {
                //Delay between each laser fire 
                nextFire = Time.time + fireRate;

                //Dot product coding courtesy of Usman at Circuit Stream
                GameObject tempLaser = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
                Rigidbody laserRb = tempLaser.GetComponent<Rigidbody>();
                float dp = Vector3.Dot(shipRb.velocity, spawnPoint.forward);
                dp = Mathf.Clamp(dp, 0, dp);
                Vector3 fwdSpeed = spawnPoint.forward * dp;
                laserRb.velocity = fwdSpeed;

                //Force added to projectile
                laserRb.AddForce(shootForce * spawnPoint.forward);

                //Laser Audio played
                audioPlayer.PlayOneShot(laserShoot);


            }
        }
    }

}
