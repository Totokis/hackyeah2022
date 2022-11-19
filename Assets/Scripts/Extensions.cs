using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    #region Array
    public static T Random<T>(this T[] values, out int index)
    {
        index = -1;
        if (values.Length == 0)
            return default;

        index = UnityEngine.Random.Range(0, values.Length);
        return values[index];
    }

    public static T Random<T>(this T[] values)
    {
        return values.Random(out var index);
    }
    #endregion

    #region List
    public static T Random<T>(this List<T> values, out int index)
    {
        index = -1;
        if (values.Count == 0)
            return default;

        index = UnityEngine.Random.Range(0, values.Count);
        return values[index];
    }

    public static T Random<T>(this List<T> values)
    {
        return values.Random(out var index);
    }
    #endregion
}
