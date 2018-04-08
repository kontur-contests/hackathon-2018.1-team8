using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct AudioItem
{
    public string Name;
    public AudioClip Clip;
}

public class PlayerAudioSource : MonoBehaviour
{
    private AudioSource source;

    [SerializeField]
    private List<AudioItem> items = new List<AudioItem>();

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayClip(string name, float volume = 1)
    {
        source.volume = volume;
        source.clip = items.FirstOrDefault(a => a.Name == name).Clip;
        if (gameObject.activeInHierarchy)
            source.Play();
    }
}
