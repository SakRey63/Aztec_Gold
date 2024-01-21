using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTheRight : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _minZ = 0.75f;
    private float _maxZ = 2.25f;

    private bool _getOpen = false;
    private bool _getClose = false;

    private int _direction = 1;

    // Update is called once per frame
    void Update()
    {
        if (_getOpen)
        {
            transform.Translate(0, 0, _direction * _speed * Time.deltaTime);
            if ((transform.position.z >= _maxZ))
            {
                _getOpen = false;
            }
        }
        if (_getClose)
        {
            transform.Translate(0, 0, -_direction * _speed * Time.deltaTime);
            if ((transform.position.z <= _minZ))
            {
                _getClose = false;
            }
        }
    }
    
    public void GoOpen()
    {
        _getOpen = true;
    }
    public void GoClose()
    {
        _getClose = true;
    }
    
}
