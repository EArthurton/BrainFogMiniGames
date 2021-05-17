using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip music;
    private AudioSource mAudio;

    public void Awake()
    {
        GameObject[] mainMusic = GameObject.FindGameObjectsWithTag("General Music");

        Debug.Log(mainMusic.Length);

        if (mainMusic.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mAudio = GetComponent<AudioSource>();
            mAudio.clip = music;
            mAudio.Play();

            DontDestroyOnLoad(this.gameObject);
        }
    }
}