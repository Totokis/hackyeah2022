using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuchaFocusTransporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocal(gameObject, new Vector3(-2.269f, transform.localPosition.y, 3.116f), 1.5f)
            .setLoopPingPong()
            .setEaseOutSine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
