using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MLevels : MonoBehaviour
{
    
    public Sprite[] sprites;
    public GameObject[] objects;
    public SpriteRenderer[] render;
    public int randomIndex;
    public Image canvasImage;
    private List<Sprite> objectSprites;
    public static List<string> objectNames;
    public Button nextButton;
    private AudioSource buttonClick;
    public AudioClip buttonClip;

    void Start()
    {
        buttonClick = GameObject.Find("SFX").GetComponent<AudioSource>();
        buttonClick.clip = buttonClip;

        objectSprites = new List<Sprite>();
        objectNames = new List<string>();

        for(int i = 0; i < sprites.Length; i++)
        {
            objectSprites.Add(sprites[i]);
        }

        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<Image>().sprite = objectSprites[Random.Range(0, objectSprites.Count)];
            render[i].sprite = objects[i].GetComponent<Image>().sprite;
            objectNames.Add(objects[i].GetComponent<Image>().sprite.name);
            objects[i].transform.localScale = render[i].bounds.size;
            objectSprites.Remove(objects[i].GetComponent<Image>().sprite);
        }
    }

    private void OnEnable()
    {
        nextButton.onClick.AddListener(AnswerScreen);
    }

    private void OnDisable()
    {
        nextButton.onClick.RemoveListener(AnswerScreen);
    }

    public void AnswerScreen()
    {
        buttonClick.Play();
        SceneManager.LoadScene("MAnswer");
    }
}