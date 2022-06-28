using head;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
public class CharacterSoundControl : MonoBehaviour
{
    public RandomAudioPlay footSource;
    public RandomAudioPlay headSource;
    public RandomAudioPlay bodySource;
    public RandomAudioPlay ballSource;

    private bool currentState;

    public DetectHead detectHead;
    private CharacterAnimation characterAnimation;
    private HeaderControl neck;
    private void Start()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        currentState = characterAnimation.Floor;
        neck = GetComponentInChildren<HeaderControl>();
    }
    public void Run(Collision collision)
    {
        if (footSource.canPlay && collision.gameObject.CompareTag("Field"))
        {
            footSource.PlayRandomClip(SOUND_KEY.foot, 0);
            footSource.audioSource.loop = true;
            footSource.canPlay = false;
        }
    }
    public void Stop()
    {
        footSource.canPlay = true;
        footSource.audioSource.Stop();
        footSource.audioSource.loop = false;
    }

    public void Head()
    {
        headSource.PlayRandomClip(SOUND_KEY.head, 0);
    }

    public void Blow()
    {
        bodySource.PlayRandomClip(SOUND_KEY.body, 0);
    }
    public void Trot()
    {
    }
    public void Jump()
    {
        footSource.PlayRandomClip(SOUND_KEY.foot, 1);
    }
    public void Fall()
    {
        footSource.PlayRandomClip(SOUND_KEY.foot, 2);
    }
    public void Dive()
    {
        bodySource.PlayRandomClip(SOUND_KEY.body, 1);
    }
    private void Update()
    {
        if (detectHead.Detect)
        {
            detectHead.Detect = false;
            Blow();
        }
        if (characterAnimation.Floor != currentState && !neck.dive)
        {
            footSource.audioSource.loop = false;
            if (currentState)
            {
                Jump();
            }
            else
            {
                Fall();
            }
            currentState = characterAnimation.Floor;

        }
    }
}
