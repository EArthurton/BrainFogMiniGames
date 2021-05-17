using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public static Sprite[] sprites;
    private GameObject[] buttons;
    private AudioSource buttonClick;
    public AudioClip buttonClip;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new GameObject[10];
        buttons[0] = GameObject.Find("RoadTile (2)");
        buttons[1] = GameObject.Find("RoadTile (8)");
        buttons[2] = GameObject.Find("RoadTile (19)");
        buttons[3] = GameObject.Find("RoadTile (22)");

        sprites = new Sprite[5];
        sprites[0] = Resources.Load<Sprite>("Sprites/roadTexture_06");
        sprites[1] = Resources.Load<Sprite>("Sprites/roadTexture_07");
        sprites[2] = Resources.Load<Sprite>("Sprites/roadTexture_13");
        sprites[3] = Resources.Load<Sprite>("Sprites/roadTexture_18");
        sprites[4] = Resources.Load<Sprite>("Sprites/roadTexture_19");

        buttons[0].GetComponent<Image>().sprite = sprites[4];
        buttons[1].GetComponent<Image>().sprite = sprites[2];
        buttons[2].GetComponent<Image>().sprite = sprites[2];
        buttons[3].GetComponent<Image>().sprite = sprites[3];

        buttonClick = GameObject.Find("SFX 02").GetComponent<AudioSource>();
        buttonClick.clip = buttonClip;
    }

    public void ChangeButton1()
    {
        buttonClick.Play();

        if(buttons[0].GetComponent<Image>().sprite == sprites[4])
        {
            buttons[0].GetComponent<Image>().sprite = sprites[3];
        }
        else if(buttons[0].GetComponent<Image>().sprite == sprites[3])
        {
            buttons[0].GetComponent<Image>().sprite = sprites[4];
        }
    }

    public void ChangeButton2()
    {
        buttonClick.Play();

        if (buttons[1].GetComponent<Image>().sprite == sprites[2])
        {
            buttons[1].GetComponent<Image>().sprite = sprites[0];
        }
        else if (buttons[1].GetComponent<Image>().sprite == sprites[0])
        {
            buttons[1].GetComponent<Image>().sprite = sprites[2];
        }
    }

    public void ChangeButton3()
    {
        buttonClick.Play();

        if (buttons[2].GetComponent<Image>().sprite == sprites[2])
        {
            buttons[2].GetComponent<Image>().sprite = sprites[1];
        }
        else if (buttons[2].GetComponent<Image>().sprite == sprites[1])
        {
            buttons[2].GetComponent<Image>().sprite = sprites[2];
        }
    }

    public void ChangeButton4()
    {
        buttonClick.Play();

        if (buttons[3].GetComponent<Image>().sprite == sprites[4])
        {
            buttons[3].GetComponent<Image>().sprite = sprites[3];
        }
        else if (buttons[3].GetComponent<Image>().sprite == sprites[3])
        {
            buttons[3].GetComponent<Image>().sprite = sprites[4];
        }
    }
}