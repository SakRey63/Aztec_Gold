using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int _damageCount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerManager.Damage(_damageCount);
    }
}
