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

    private int _score = 0;
    private int _hit = 10;
    private Rigidbody _rb;
    private bool _isGrounded;
    private MovingToTheRight _movingToTheRight;
    private MovingToTheLeft _movingToTheLeft;
    private ForthBlockOfStone _forthBlockOfStone;
    private EnemySpawner _enemySpawner;
    private SupportOff _support;
    private BridgeIsDisappearing _bridgeIsDisappearing;
    private TurningGrid _turningGrid;
    private EnemySpawner _stoneSpawn;

    private void Start()
    {
        _enemySpawner.SpawnOnStart();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * _movementSpeed));
        transform.Rotate(Vector3.up * _rotateSpeed * Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
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
            _score += _hit;
            Destroy(other.gameObject);
            Debug.Log($"Skeleton score {_score}");
        }

        Trap trap = other.gameObject.GetComponent<Trap>();
        if (trap != null)
        {
            // _support.Support();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Stone1 stone1 = other.gameObject.GetComponent<Stone1>();
        if (stone1 != null)
        {
            _stoneSpawn.SpawnStones();
        }
        
        SupportOff sup = other.gameObject.GetComponent<SupportOff>();
        if (sup != null)
        {
            Destroy(other.gameObject);
        }
        Stone stone = other.gameObject.GetComponent<Stone>();
        if (stone != null)
        {
            _forthBlockOfStone.GoRun();
            _enemySpawner.Spawn();
        }
        
        GridTrigger grid = other.gameObject.GetComponent<GridTrigger>();
        if (grid != null)
        {
            _turningGrid.RotateGrid();

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

        BridgeTrigger trigger = other.gameObject.GetComponent<BridgeTrigger>();
        if (trigger != null)
        {
            _bridgeIsDisappearing.BridgeOf();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        GateActivator component = other.gameObject.GetComponent<GateActivator>();
        if (component != null)
        {
            _movingToTheRight.GoClose();
            _movingToTheLeft.GoClose();
        }
    }

    public void Stones(EnemySpawner stone)
    {
        _stoneSpawn = stone;
    }

    public void Turning(TurningGrid turning)
    {
        _turningGrid = turning;
    }

    public void SetBridgeOf(BridgeIsDisappearing trigger)
    {
        _bridgeIsDisappearing = trigger;
    }
    
    public void SetSpawner(EnemySpawner spawner)
         {
             _enemySpawner = spawner;
         }

    public void SupportOn(SupportOff support)
    {
        _support = support;
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
