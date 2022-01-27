using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;
    public AudioSource AudioSource;
    public AudioLowPassFilter AudioLowPassFilter;
    public List<sound> sounds;
    private void Awake()
    {
        foreach (var soundItem in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.loop = false;
            source.playOnAwake = false;
            source.clip = soundItem.clip;
            source.volume = soundItem.volume;
            soundItem.AudioSource = source;
        }
/*        AudioSource = GetComponent<AudioSource>();
        AudioLowPassFilter = GetComponent<AudioLowPassFilter>();
        AudioLowPassFilter.enabled = true;*/
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void playSound(string name)
    {
        foreach (var obj in sounds)
        {
            if (obj.name == name)
            {
                obj.AudioSource.pitch = Random.Range(obj.minPitch, obj.maxPitch);
                obj.AudioSource.Play();
                break;
            }
        }
    }
}
[System.Serializable]
public class sound
{
    public string name;
    [Range(0, 3)]
    public float minPitch;
    [Range(0, 3)]
    public float maxPitch;
    [Range(0, 1)]
    public float volume;
    public AudioClip clip;
    public AudioSource AudioSource;
}
