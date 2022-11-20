using UnityEngine;

[System.Serializable]
public class MinMaxVector3
{
    [field: SerializeField] public Transform Min;
    [field: SerializeField] public Transform Max;

    public Vector3 Random()
    {
        var direction = (Max.position - Min.position).normalized;
        var distance = Vector3.Distance(Min.position, Max.position);
        return Min.position + direction * UnityEngine.Random.Range(0, distance);
    }
}
