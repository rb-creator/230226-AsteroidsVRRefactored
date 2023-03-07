using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _timeTillDestruct = 5.0f;

    void Start()
    {
        Invoke("ReturnToPool", _timeTillDestruct);

        //Destroy(gameObject, _timeTillDestruct);
        //Debug.Log("This projectile will be destroyed in 5s if it doesn't collide");
    }

    void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
