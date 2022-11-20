using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Linq;
using UnityEngine;

public class Fly : MonoBehaviour
{
    // Drag & drop the player in the inspector
    public Transform Target;

    public float RotationSpeed = 1;

    public float CircleRadius = 1;

    public float ElevationOffset = 0;

    private Vector3 positionOffset;
    private float angle;

    private Single _offsetX;
    private Single _offsetY;
    private Single _offsetZ;

    Boolean positiveSinus = true;
    Boolean positiveCos = true;
    private void Start()
    {
        SHUFFLEVALUES();
        StartCoroutine(SHUFFLECOR());
    }

    private void SHUFFLEVALUES()
    {
        _offsetX = UnityEngine.Random.Range(-1f, 1f);
        _offsetY = UnityEngine.Random.Range(-1f, 1f);
        _offsetZ = UnityEngine.Random.Range(-1f, 1f);
        positiveCos = UnityEngine.Random.value > 0.5f;
        positiveSinus = UnityEngine.Random.value > 0.5f;

    }

    private IEnumerator SHUFFLECOR()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
        SHUFFLEVALUES();
        StartCoroutine(SHUFFLECOR());
    }

    private void LateUpdate()
    {
        positionOffset.Set(
            positiveCos ? 1 : -1 * Mathf.Cos(angle * _offsetX) * CircleRadius,
            ElevationOffset,
            positiveSinus ? 1 : -1 * Mathf.Sin(angle * _offsetZ) * CircleRadius
        );
        transform.position = Target.position + positionOffset
            + new Vector3(_offsetX, _offsetY, _offsetZ);
        angle += Time.deltaTime * RotationSpeed;
    }

    Vector3 _lastFrame;
    void Update()
    {
        Vector3 newForward = transform.position - _lastFrame;
        if (newForward != Vector3.zero)
        {
            transform.forward = newForward;
        }
        _lastFrame = transform.position;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

}
