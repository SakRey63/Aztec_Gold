using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeIsDisappearing : MonoBehaviour
{
    private bool _bridgeOf = false;
    // Update is called once per frame
    void Update()
    {
        if (_bridgeOf)
        {
            Destroy(gameObject);
        }
    }

    public void BridgeOf()
    {
        _bridgeOf = true;
    }
}
