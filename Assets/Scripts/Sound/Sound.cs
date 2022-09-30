using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]   //sesleri bu sýnýfta tutacaðýz
public class Sound //dikkat edilirse burada monobehaviour yok. çünkü bu bir Serializable sýnýf
{

    public string name;
    public AudioClip clip;
    public float volume;
    public bool loop;
    public AudioSource source;


}
