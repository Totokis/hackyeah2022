using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    public Transform[] trPath;

    private List<Vector3> _pathFinal = new List<Vector3>();

    // Start is called before the first frame update
    Single _initialRot;
    void Start()
    {
        _initialRot = transform.localEulerAngles.x;
        if (trPath == null || trPath.Length == 0)
        {
            Debug.LogError($"Zwierz¹tko {name} ni ma trasy ruszania sie");
            return;
        }

        for (int i = 0; i < trPath.Length; i++)
        {
            //if (i == 0 || i == trPath.Length - 1)
            //{
            //    _pathFinal.Add(trPath[i].position);
            //}
            _pathFinal.Add(trPath[i].position);

        }

        StartCoroutine(AnimalMovement());

    }

    private Int32 _moves = 0;
    private Boolean _iterateForward = true;
    private IEnumerator AnimalMovement()
    {
        //Int32 movesLocal = _moves % _pathFinal.Count;
        if (_moves == 0)
        {
            _iterateForward = true;
            yield return new WaitForSeconds(Random.Range(5.5f, 10f));

        }
        else
        {
            if (_moves == _pathFinal.Count - 1)
                _iterateForward = false;

            yield return new WaitForSeconds(Random.Range(5.5f, 10f));
        }

        if (_iterateForward)
            _moves++;
        else
            _moves--;

        LeanTween.move(gameObject, _pathFinal[_moves], UnityEngine.Random.Range(2.222f, 5f));

        StartCoroutine(AnimalMovement());
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
        transform.localEulerAngles = new Vector3(_initialRot, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
