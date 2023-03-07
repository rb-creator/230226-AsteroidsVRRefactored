using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private string _triggerButton;
    [SerializeField] private string _boostButton;
    [SerializeField] private float _fireRate = 0.15f;
    private float _nextFire = 0f;
    private Transform _spawnPoint;
    private AudioSource _audioPlayer;
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
            //Right Controller Trigger instantiates laser projectile every x seconds
            if (Input.GetButton(_triggerButton) && Time.time > _nextFire)
            {
                //Delay between each laser fire 
                _nextFire = Time.time + _fireRate;
                //Instantiate(_projectilePrefab, _spawnPoint.position, _projectilePrefab.transform.rotation);
                GameObject laser = _laserObjectPool.GetPooledObject();

                if(laser != null)
                {
                    laser.transform.position = _spawnPoint.position;
                    laser.SetActive(true);
                }
                _audioPlayer.Play();
            }
        }
    }
}
