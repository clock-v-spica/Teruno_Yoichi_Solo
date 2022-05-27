using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationFloor : MonoBehaviour
{
    [SerializeField]
    List<WaveProcessor> waves;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = position;

        waves.ForEach((w) =>
        {
            pos = w.Process(pos);
            w.AddTime(Time.deltaTime);
        });
        transform.position = Vector3.Lerp(transform.position, pos, 0.02f);
    }
}
