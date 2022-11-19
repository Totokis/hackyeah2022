using UnityEngine;
using Random = UnityEngine.Random;

public class MandingoController : MonoBehaviour
{
    private void Start()
    {
        print($"Mandingo load completed in: {Random.Range(0,100f):N2}%");
    }
}
