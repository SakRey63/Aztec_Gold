using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fall : MonoBehaviour
{
    // [SerializeField] private float _speed;
    // [SerializeField] private float _direction;
    [SerializeField] private float _timeToDestroy;
    

    private void OnTriggerEnter(Collider other)
    {
        Water water = other.gameObject.GetComponent<Water>();
        if (water != null)
        {
            Destroy(gameObject, _timeToDestroy);
        }
    }
}
