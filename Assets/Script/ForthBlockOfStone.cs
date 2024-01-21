using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ForthBlockOfStone : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    

    // В каком направлении объект движется в данный момент
    private int _direction = 1;

    private bool _run = false;
    

    // Update is called once per frame
    public void Update()
    {
        if (_run)
        {
            transform.Translate(0, 0, _direction * _speed * Time.deltaTime);
        }
        
    }

    public void GoRun()
    {
        _run = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        Bridge component = other.gameObject.GetComponent<Bridge>();
        if (component != null)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Lava component = other.gameObject.GetComponent<Lava>();
        if (component != null)
        {
            Destroy(gameObject, _timeToDestroy);
        }
    }
}
