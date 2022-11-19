using UnityEngine;

[System.Serializable]
public class MinMaxVector3
{
    [field: SerializeField] public Vector3 Min;
    [field: SerializeField] public Vector3 Max;

    public Vector3 Random()
    {
        var x = UnityEngine.Random.Range(Min.x, Max.x);
        var y = UnityEngine.Random.Range(Min.y, Max.y);
        var z = UnityEngine.Random.Range(Min.z, Max.z);
        return new Vector3(x, y, z);
    }
}
