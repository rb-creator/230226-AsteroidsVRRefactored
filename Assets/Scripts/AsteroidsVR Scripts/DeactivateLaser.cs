using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateLaser : MonoBehaviour
{
    [SerializeField] private float _distance = 100f;
    private Transform _spawnPoint;

    void Start()
    {
        _spawnPoint = GameObject.Find("ProjectileSpawner").GetComponent<Transform>();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Vector3.Distance(transform.position, _spawnPoint.transform.position) > _distance)
                gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
        }
    }

}