using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_control : MonoBehaviour
{

    [SerializeField] AudioSource Bgm;
    [SerializeField] AudioSource Sfx;
    public AudioClip click;
    public AudioClip forest;
    public AudioClip bossbegin;
    public AudioClip fight;
    public AudioClip vict;
    public AudioClip buffchoose;
    public AudioClip mainbgm;

    // Start is called before the first frame update
    void Start()
    {
        Bgm.clip = mainbgm;
        Bgm.loop = true;

        Bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playmusic(AudioClip music)
    {
        Sfx.PlayOneShot(music);
    }

    public void Playbgm(AudioClip sound)
    {
        Bgm.clip = sound;
        Bgm.loop = true;
        Bgm.Play();
    }
}
