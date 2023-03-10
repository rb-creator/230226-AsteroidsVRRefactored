using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    //Asteroid Particle Explosion
    private ParticleSystem _explosionParticle;
    private bool _particleEnabled;
    private bool _hasBeenHit;
    private MeshRenderer _asteroidRenderer;

    //Audio Variables
    private AudioSource _audioPlayer;
    [SerializeField] private AudioClip _explosionAudio;
   
    void Start()
    {
        _audioPlayer = GameObject.Find("ProjectileSpawner").GetComponent<AudioSource>();
        _explosionParticle = gameObject.GetComponentInChildren<ParticleSystem>();

        //Set particle emission
        var emission = _explosionParticle.emission;
        emission.enabled = _particleEnabled;
        _particleEnabled = true;

        //Set Meshrenderer
        _asteroidRenderer = GetComponent<MeshRenderer>();
        _hasBeenHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser") && !_hasBeenHit)
        {
            //Disable asteroid meshrenderer, start particle effect, play explosion SFX  
            _asteroidRenderer.enabled = !_asteroidRenderer.enabled;
            _explosionParticle.Play();
            _audioPlayer.PlayOneShot(_explosionAudio);
            _hasBeenHit = true;
            StartCoroutine(StopExplosion());
        }

        IEnumerator StopExplosion()
        {
            //Stop particle effect
            yield return new WaitForSeconds(0.1f);
            _particleEnabled = false;
        }
    }
}
