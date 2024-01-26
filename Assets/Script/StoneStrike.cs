using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStrike : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject, 1.0f);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Destroy(gameObject, 2.0f);
        }
    }
    
    
}
