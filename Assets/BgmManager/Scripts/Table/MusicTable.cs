using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "MyGame/Create MusicTable", fileName = "MusicTable" )]
public class MusicTable : ScriptableObject
{
    public AudioClip clip;
    public float loopBeginTime;
    public float volume = 1;
}
