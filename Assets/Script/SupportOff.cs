using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportOff : MonoBehaviour
{
    
    private bool _isDestroy = false;
    
    void Update()
    {
        if (_isDestroy)
        {
            Destroy(gameObject);
        }
    }
    public void Support()
    {
        Debug.Log("OK");
        _isDestroy = true;
    }
}
