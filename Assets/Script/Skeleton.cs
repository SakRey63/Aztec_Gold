using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour

{
    
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpHeight;

    private Rigidbody _rb;
    private bool _isGrounded;
    private MovingToTheRight _movingToTheRight;
    private MovingToTheLeft _movingToTheLeft;
    private ForthBlockOfStone _forthBlockOfStone;
    private EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner.SpawnOnStart();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * _movementSpeed));
        transform.Rotate(Vector3.up * _rotateSpeed * Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space) && !_isGrounded);
        {
            _rb.AddForce(Vector3.up * _jumpHeight);
        }
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        
        
        Debug.Log($"Skeleton collision enter {other.gameObject.name}");
        Ork component = other.gameObject.GetComponent<Ork>();
        if (component != null)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Grounded"))
        {
            _isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grounded"))
        {
            _isGrounded = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Stone stone = other.gameObject.GetComponent<Stone>();
        if (stone != null)
        {
            _forthBlockOfStone.GoRun();
            _enemySpawner.Spawn();
        }
        
        
        GateActivator component = other.gameObject.GetComponent<GateActivator>();
        if (component != null)
        {
            _movingToTheRight.GoOpen();
            _movingToTheLeft.GoOpen();
        }

        Lava lava = other.gameObject.GetComponent<Lava>();
        if (lava != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        GateActivator component = other.gameObject.GetComponent<GateActivator>();
        if (component != null)
        {
            _movingToTheRight.GoClose();
            _movingToTheLeft.GoClose();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // Debug.Log($"Skeleton trigger stay {other.gameObject.name}");
    }
    public void SetSpawner(EnemySpawner spawner)
         {
             _enemySpawner = spawner;
         }

    public void SetRun(ForthBlockOfStone run)
    {
        _forthBlockOfStone = run;
    }

    public void OpenRight(MovingToTheRight open)
    {
        _movingToTheRight = open;
    }
    public void OpenLeft(MovingToTheLeft open)
    {
        _movingToTheLeft = open;
    }
}
