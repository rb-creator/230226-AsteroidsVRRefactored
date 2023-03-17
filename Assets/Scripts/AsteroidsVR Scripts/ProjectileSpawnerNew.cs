using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawnerNew : MonoBehaviour
{
    [SerializeField] private InputActionAsset _xRIActions;
    InputAction _boostAction;
    InputAction _shootLaserAction;
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

        _boostAction = _xRIActions.FindActionMap("XRI RightHand RocketController").FindAction("Boost");
        _shootLaserAction = _xRIActions.FindActionMap("XRI RightHand RocketController").FindAction("ShootLaser");
    }

    private void OnEnable()
    {
        _xRIActions.FindActionMap("XRI RightHand RocketController").Enable();
    }
    private void OnDisable()
    {
        _xRIActions.FindActionMap("XRI RightHand RocketController").Disable();
    }

    void Update()
    {
        if (!_boostAction.IsPressed())
        {
            //Right Controller Trigger fires laser projectile after specific duration
            if (_shootLaserAction.IsPressed() && Time.time > _nextFire)
            {
                SpawnProjectile();
            }
        }
    }

    private void SpawnProjectile()
    {
        //Delay between each laser fire 
        _nextFire = Time.time + _fireRate;
        //Get laser from LaserObjectPool
        GameObject laser = _laserObjectPool.GetPooledObject();
        //Spawn laser at spawnpoint
        if (laser != null)
        {
            laser.transform.position = _spawnPoint.position;
            laser.transform.rotation = _spawnPoint.rotation;
            laser.SetActive(true);
        }
        //Play Laser Fire Audio
        _audioPlayer.PlayOneShot(_laserFire);
    }
}
