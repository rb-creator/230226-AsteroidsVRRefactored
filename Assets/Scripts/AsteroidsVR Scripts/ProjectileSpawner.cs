using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private string _triggerButton;
    [SerializeField] private string _boostButton;
    private float _fireRate = 0.15f;
    private float _nextFire = 0f;
    private Transform _spawnPoint;
    private AudioSource _audioPlayer;
    [SerializeField] private AudioClip _laserFire;
    private LaserObjectPool _laserObjectPool;

    private void Awake()
    {
        _spawnPoint = GetComponent<Transform>();
        _audioPlayer = GetComponent<AudioSource>();
        _laserObjectPool = GetComponent<LaserObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnProjectile();
    }

    void SpawnProjectile()
    {
       if (!Input.GetButton(_boostButton))
        {
            //Right Controller Trigger fires laser projectile every x seconds
            if (Input.GetButton(_triggerButton) && Time.time > _nextFire)
            {
                //Delay between each laser fire 
                _nextFire = Time.time + _fireRate;
                //Get laser from LaserObjectPool
                GameObject laser = _laserObjectPool.GetPooledObject();
                //Spawn laser at spawnpoint
                if(laser != null)
                {
                    laser.transform.position = _spawnPoint.position;
                    laser.SetActive(true);
                }
                //Play Laser Fire Audio
                _audioPlayer.PlayOneShot(_laserFire);
            }
        }
    }
}
