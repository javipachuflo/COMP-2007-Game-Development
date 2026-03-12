using UnityEngine;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;

/// <summary>
/// Extension class to hold all our extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// shuffles any type list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this List<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    /// resets any transform to the default
    /// </summary>
    /// <param name="thisTransform"></param>
    public static void Reset(this Transform thisTransform)
    {
        thisTransform.position = Vector3.zero;
        thisTransform.rotation = Quaternion.identity;
        thisTransform.localScale = Vector3.one;
    }
}
