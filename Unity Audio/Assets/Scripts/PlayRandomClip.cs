using UnityEngine;

/* 
 * PlayRandomClip plays a random clip at specified time intervals
 * clips
 *   - an array of AudioClips to use
 *   - delay the time between playing a clip
 */

public class PlayRandomClip : MonoBehaviour
{
    // The AudioClip class deals with any imported audio files inside of unity
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/AudioClip.html
    public AudioClip[] clips;

    // delay is the wait time between playing a random clip
    public float delay = 0.5f;

    // AudioSource is the component we will play our clip on
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/AudioSource.html
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // the custom method Footstep will play the clip repeatedly using Invoke
        Footstep();
    }

    // Footstep selects and plays a random audio clip
    private void Footstep()
    {
        // the AudioSource component has a clip property we can add an AudioClip to
        // we select a random AudioClip from the clips array using Random.Range
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/AudioSource-clip.html
        audioSource.clip = clips[Random.Range(0, clips.Length - 1)];

        // AudioSource can play a clip by running its Play method
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/AudioSource.Play.html
        audioSource.Play();

        // We loop the Footsteps method by calling Invoke here
        // NOTE: we are calling the Footstep method, hence we are looping in infinitely
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.Invoke.html
        // NOTE: we can call CancelInvoke if we want to stop looping
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.CancelInvoke.html
        Invoke(nameof(Footstep), delay);
    }
}
