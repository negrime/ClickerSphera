using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    private AudioSource _source;

    public void SetSource(AudioSource source)
    {
        _source = source;
        source.clip = clip;
    }

    public void Play()
    {
        _source.Play();   
    }
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] 
    private Sound[] _sounds;
    
    void Start()
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + _sounds[i].name);
            _go.transform.SetParent(this.transform);
            _sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            if (_sounds[i].name.Contains(name))
            {
                _sounds[i].Play();
            }
        }
    }
}
