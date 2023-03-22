using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void Update()
    {
        transform.LookAt(_destination);
    }
}
