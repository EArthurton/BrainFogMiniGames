using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFX : MonoBehaviour
{
    public AudioClip gMusic;
    private AudioSource gAudio;

    public void Update()
    {
        gAudio = GetComponent<AudioSource>();
        gAudio.clip = gMusic;

        for(int i = 0; i < 10; i++)
        {
            if(CarMovement.firstCarsColl[i] != null)
            {
                if (CarMovement.firstCarsColl[i].bounds.Intersects(CarMovement.blueCollider.bounds) || CarMovement.firstCarsColl[i].bounds.Intersects(CarMovement.greenCollider.bounds) || CarMovement.firstCarsColl[i].bounds.Intersects(CarMovement.orangeCollider.bounds) || CarMovement.firstCarsColl[i].bounds.Intersects(CarMovement.pinkCollider.bounds) || CarMovement.firstCarsColl[i].bounds.Intersects(CarMovement.purpleCollider.bounds))
                {
                    gAudio.Play();
                }
            }

            if (CarMovement.secondCarsColl[i] != null)
            {
                if (CarMovement.secondCarsColl[i].bounds.Intersects(CarMovement.blueCollider.bounds) || CarMovement.secondCarsColl[i].bounds.Intersects(CarMovement.greenCollider.bounds) || CarMovement.secondCarsColl[i].bounds.Intersects(CarMovement.orangeCollider.bounds) || CarMovement.secondCarsColl[i].bounds.Intersects(CarMovement.pinkCollider.bounds) || CarMovement.secondCarsColl[i].bounds.Intersects(CarMovement.purpleCollider.bounds))
                {
                    gAudio.Play();
                }
            }
        }
    }
}