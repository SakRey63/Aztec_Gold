using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MovingToTheLeft : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private float _minZ = -0.75f;
    private float _maxZ = -2.25f;
    
    private int _direction = 1;

    private bool _getOpen = false;
    private bool _getClose = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_getOpen)
        {
            transform.Translate(0, 0, -_direction * _speed * Time.deltaTime);
            if (transform.position.z <= _maxZ)
            {
                _getOpen = false;
            }
        }
        if (_getClose)
        {
            transform.Translate(0, 0, _direction * _speed * Time.deltaTime);
            if (transform.position.z >= _minZ)
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
