using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]   //sesleri bu s�n�fta tutaca��z
public class Sound //dikkat edilirse burada monobehaviour yok. ��nk� bu bir Serializable s�n�f
{

    public string name;
    public AudioClip clip;
    public float volume;
    public bool loop;
    public AudioSource source;


}
