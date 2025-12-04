using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [SerializeField] private AudioSource SFXObj;

    private void Awake()
    {
        if ( Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip clip, Transform spawnTrasform, float volume)
    {
        // spawn in gameObject
        AudioSource source  = Instantiate(SFXObj, spawnTrasform.position, Quaternion.identity);
        
        // assign the audio clip
        source.clip = clip;
        
        // play sound 
        source.volume = volume;
        
        // get length of the SFX clip
        float clipLength = source.clip.length;
        
        // destroy the clip after it is done playing
        Destroy(source.gameObject, clipLength);
    }
}
