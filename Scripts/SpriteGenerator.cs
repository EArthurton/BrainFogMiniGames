using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGenerator : MonoBehaviour
{
    public int randomIndex;
    public static Sprite[] cars;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        cars = new Sprite[5];

        cars[0] = Resources.Load<Sprite>("Sprites/Cars/BlueCar");
        cars[1] = Resources.Load<Sprite>("Sprites/Cars/GreenCar");
        cars[2] = Resources.Load<Sprite>("Sprites/Cars/OrangeCar");
        cars[3] = Resources.Load<Sprite>("Sprites/Cars/PinkCar");
        cars[4] = Resources.Load<Sprite>("Sprites/Cars/PurpleCar");

        GenerateSprite();
    }

    void GenerateSprite()
    {
        randomIndex = Random.Range(0, cars.Length);
        car.GetComponent<Image>().sprite = cars[randomIndex];
        car.transform.localScale = new Vector2(0.5f, 0.8f);
        car.transform.Rotate(new Vector2(0, 180f));
    }
}
