using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager inst;

    public AudioSource source;

    public List<AudioSource> AudioClips = new List<AudioSource>();


    private void Awake()
    {
        inst = this;
        Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
