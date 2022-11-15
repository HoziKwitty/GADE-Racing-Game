using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager inst;

    public AudioSource source;

    public List<AudioClip> AudioClips = new List<AudioClip>();


    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        var audioClips = new Dictionary<string, AudioClip>();

        foreach (var audio in AudioClips)
        {
            audioClips.Add(audio.name, audio);
        }

        source = GetComponent<AudioSource>();
        source.PlayOneShot(audioClips["Background_music"]);

    }
}
