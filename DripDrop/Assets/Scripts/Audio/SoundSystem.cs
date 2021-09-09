using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// A basic sound system that can play sounds as soneshots.
/// </summary>
public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private SoundItem[] sounds = new SoundItem[0];
    
    public bool debugSounds = false;
    
    private static bool instanced = false;
    private static SoundSystem instance = null;
    private void Awake()
    {
        instance = this;
    }

    public static SoundSystem Instance()
    {
        if (!instanced)
        {
            instance = FindObjectOfType<SoundSystem>();
            instanced = instance != null;
        }

        return instance;
    }
    
    public void PlaySound(string name, float minPitch = 1, float maxPitch = 1)
    {
        if (minPitch == maxPitch && minPitch == 1)
        {
            audioSource.pitch = 1f;
        }
        else
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }

        for (int i = 0; i < instance.sounds.Length; i++)
        {
            if (instance.sounds[i].Name.Equals(name))
            {
                var clip = instance.sounds[i].GetSound();
                if(debugSounds)
                    Debug.Log($"Playing sound: {name} with volume {instance.sounds[i].volume:P0}. Clip: {clip.name}");
                instance.audioSource.PlayOneShot(clip, instance.sounds[i].volume);
                return;
            }
        }
        Debug.LogWarning($"SoundSystem: Sound '{name}' was not found in the list.");
    }

    [Serializable]
    public class SoundItem
    {
        public string Name;
        [Range(0f,1f)]
        public float volume = 1f;
        public AudioClip[] clips;

        public AudioClip GetSound()
        {
            return clips[UnityEngine.Random.Range(0, clips.Length)];
        }
    }
}
