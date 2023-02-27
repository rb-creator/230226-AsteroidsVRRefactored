using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    //Asteroid Movement
    public float minSpinSpeed = 1f;
    public float maxSpinSpeed = 5f;
    public float minThrust = 0.1f;
    public float maxThrust = 0.5f;
    private float spinSpeed;

    //Asteroid Explosion
    public ParticleSystem explosionParticle;
    public bool particleEnabled;
    public bool hasBeenHit;
    private MeshRenderer asteroidRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Set particle emission
        var emission = explosionParticle.emission;
        emission.enabled = particleEnabled;
        particleEnabled = true;

        //Set Meshrenderer
        asteroidRenderer = GetComponent<MeshRenderer>();
        hasBeenHit = false;

        //Set spin
        spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
        float thrust = Random.Range(minThrust, maxThrust);

        Rigidbody asteroidRb = GetComponent<Rigidbody>();
        asteroidRb.AddForce(transform.forward * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser") && !hasBeenHit)
        {
            //Disable asteroid meshrenderer, start particle effect  
            asteroidRenderer.enabled = !asteroidRenderer.enabled;
            explosionParticle.Play();
            hasBeenHit = true;
            StartCoroutine(StopExplosion());
        }

        IEnumerator StopExplosion()
        {
            //Stop particle effect
            yield return new WaitForSeconds(0.1f);
            particleEnabled = false;    
        }


    }
}
