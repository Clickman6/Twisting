using System;
using UnityEngine;

[Serializable]
public class CustomAudio {
    public AudioClip Source;

    [Range(0f, 1f)] public float Volume = 1f;
}
