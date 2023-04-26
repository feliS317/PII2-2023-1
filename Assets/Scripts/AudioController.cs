using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource[] sfxChannel;
    WaitForSeconds cleanTime = new WaitForSeconds(2f);
    public void PlaySfx(AudioClip clip)
    {
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            if (sfxChannel[i].clip == null)
            {
                sfxChannel[i].clip = clip;
                sfxChannel[i].Play();
                StartCoroutine(CleanAudioChannel(i));
                break;
            }
        }
    }
    IEnumerator CleanAudioChannel(int channel)
    {
        yield return cleanTime;
        sfxChannel[channel].clip = null;
    }
}
