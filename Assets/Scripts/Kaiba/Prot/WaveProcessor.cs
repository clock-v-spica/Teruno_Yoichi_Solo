using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveProcessor
{
    public Vector3 waveVector;
    public float time;
    public float timeScale;

    public Vector3 Process(Vector3 origin)
    {
        var vec = new Vector3();
        vec.x = Mathf.Cos(time * 2 * Mathf.PI * waveVector.x);
        vec.y = Mathf.Sin(time * 2 * Mathf.PI * waveVector.y);
        vec.z = Mathf.Cos(time * 2 * Mathf.PI * waveVector.z);
        return origin + vec;
    }

    public void AddTime(float t)
    {
        time += t * timeScale;
    }
}
