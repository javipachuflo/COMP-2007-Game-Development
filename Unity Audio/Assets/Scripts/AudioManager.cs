using UnityEngine;

// To use AudioMixer in a script, we need to import the UnityEngine.Audio library
using UnityEngine.Audio;

/*
 * AudioManager sets the volume on mixer groups
 * NOTE: the Mixer groups are already configured for this, please follow the video on the DLE for more details on setup
 * mixer
 *   - The AudioMixer asset used for controlling volumes
 *   - We can control volumes on 4 MixerGroup assets using the following public methods
 *      - SetMasterVolume
 *      - SetMusicVolume
 *      - SetSFXVolume
 *      - SetUIVolume
 *      
 * Included is a utility method (LinearToDecibel) for converting decibels to a float (0-1) value
 */

public class AudioManager : MonoBehaviour
{
    // The AudioMixer asset can be added to a component for scripting
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Audio.AudioMixer.html
    public AudioMixer mixer;

    // Here are public methods for adjusting the volume on each mixer group
    // This method sets the volume on the Master mixer group
    // NOTE: these are setup previously in the editor, please check the project and video for implementation
    public void SetMasterVolume(float newVolume)
    {
        //mixer.SetFloat("MasterVolume", newVolume);

        // SetVolume is a custom method for setting the volume on any of our AudioMixer groups
        SetVolume(newVolume, "MasterVolume");
    }

    // This method sets the volume on the Music mixer group
    public void SetMusicVolume(float newVolume)
    {
        SetVolume(newVolume, "MusicVolume");
    }

    // This method sets the volume on the SFX mixer group
    public void SetSFXVolume(float newVolume)
    {
        SetVolume(newVolume, "SFXVolume");
    }

    // This method sets the volume on the UI mixer group
    public void SetUIVolume(float newVolume)
    {
        SetVolume(newVolume, "UIVolume");
    }

    // SetVolume sets the volume on an AudioMixer group
    private void SetVolume(float volume, string type)
    {
        float vol;
        // Here we get the current volume from the AudioMixer using GetFloat
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Audio.AudioMixer.GetFloat.html
        if (mixer.GetFloat(type, out vol))
        {
            // Here we set the volume on the mixer using SetFloat
            // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Audio.AudioMixer.SetFloat.html
            // NOTE: LinearToDecimal is a custom method, see below
            mixer.SetFloat(type, LinearToDecibel(volume));
        }
    }

    // LinearToDecibel converts a float value between 0-1 into decibels for use in the mixer
    // We don't need to do this, but it results in a nicer range between quiet and loud in our mix
    // Decibels are actually a logarithmic calculation, more info below
    // https://en.wikipedia.org/wiki/Decibel
    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }
}
