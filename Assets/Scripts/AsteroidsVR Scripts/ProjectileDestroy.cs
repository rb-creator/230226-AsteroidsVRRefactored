using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    private float destroyDelay = 5f;

    //Audio Variables
    public AudioSource audioPlayer;
    public AudioClip explosion;

    private MeshRenderer laserRenderer;

    private void Start()
    {
            Destroy(gameObject, destroyDelay);
            //Debug.Log("This will be destroyed in 5 secs if it doesn't collide");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            audioPlayer.PlayOneShot(explosion);
            //laserRenderer.enabled = !laserRenderer.enabled;
            Destroy(gameObject,2f);
            Destroy(collision.gameObject,2f);
            //Debug.Log("Destroyed colliding with Asteroid"); 
        }

        else
        {
            Destroy(gameObject);
            //Debug.Log("Destroyed hitting a planet");
        }


    }

}
