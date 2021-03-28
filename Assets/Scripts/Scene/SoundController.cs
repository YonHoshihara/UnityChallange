using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip attack;
    public AudioClip button;
    public AudioClip cancel;
    public AudioClip collect;
    public AudioClip dice;
    public AudioClip getDamage;
    public AudioClip move;

    public AudioSource audio;

    // Update is called once per frame
    private void playSound(AudioClip sound, bool loop)
    {
        audio.clip = sound;
        audio.loop = loop;
        audio.Play();
    }

    private void stopSound(AudioClip sound)
    {
        audio.clip = sound;
        audio.loop = false;
        audio.Stop();
    }

    public void playAttackSound()
    {
        playSound(attack, false);
    }

    public void playButtonSound()
    {
        playSound(button, false);
    }

    public void playCancelSound()
    {
        playSound(cancel, false);
    }

    public void playCollectSound()
    {
        playSound(collect, false);
    }

    public void playDiceSound()
    {
        playSound(dice, false);
    }

    public void playGetDamageSound()
    {
        playSound(getDamage, false);
    }

    public void plaMoveSound()
    {
        playSound(move, false);
    }
}
