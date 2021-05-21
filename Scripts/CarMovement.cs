using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CarMovement : MonoBehaviour
{
    private GameObject corner, btn1, btn2, btn3, btn4, timer, scoreObject, pause, paused, cont, menu, cars, houses, roads;
    public GameObject[] firstCars, secondCars;
    //public Rigidbody2D[] firstCarsRB, secondCarsRB;
    public static BoxCollider2D cornerCollider, btn1Collider, btn2Collider, btn3Collider, btn4Collider, blueCollider, greenCollider, orangeCollider, pinkCollider, purpleCollider;
    public static BoxCollider2D[] firstCarsColl, secondCarsColl, thirdCarsColl, fourthCarsColl;
    public Button pauseButton, contButton, menuButton;
    private bool gamePaused;
    public static float countUpTimer, firstTimer, secondTimer, thirdTimer, fourthTimer;
    public static int score, i;
    private AudioSource buttonClick, shapeClick;
    public AudioClip buttonClip, shapeClip;
    private Text scoreText, timeText;

    // Start is called before the first frame update
    public void Start()
    {
        buttonClick = GameObject.Find("SFX 01").GetComponent<AudioSource>();
        shapeClick = GameObject.Find("SFX 02").GetComponent<AudioSource>();

        buttonClick.clip = buttonClip;
        shapeClick.clip = shapeClip;

        corner = GameObject.Find("RoadTile (15)");
        btn1 = GameObject.Find("RoadTile (2)");
        btn2 = GameObject.Find("RoadTile (8)");
        btn3 = GameObject.Find("RoadTile (19)");
        btn4 = GameObject.Find("RoadTile (22)");

        timer = GameObject.Find("Time");
        scoreObject = GameObject.Find("Score");
        cars = GameObject.Find("Cars");
        houses = GameObject.Find("Houses");
        roads = GameObject.Find("Road");
        paused = GameObject.Find("Paused");
        pause = GameObject.Find("Pause Button");
        cont = GameObject.Find("Continue Button");
        menu = GameObject.Find("Main Menu Button");

        cornerCollider = corner.GetComponent<BoxCollider2D>();
        btn1Collider = btn1.GetComponent<BoxCollider2D>();
        btn2Collider = btn2.GetComponent<BoxCollider2D>();
        btn3Collider = btn3.GetComponent<BoxCollider2D>();
        btn4Collider = btn4.GetComponent<BoxCollider2D>();

        blueCollider = GameObject.Find("Blue House").GetComponent<BoxCollider2D>();
        greenCollider = GameObject.Find("Green House").GetComponent<BoxCollider2D>();
        orangeCollider = GameObject.Find("Orange House").GetComponent<BoxCollider2D>();
        pinkCollider = GameObject.Find("Pink House").GetComponent<BoxCollider2D>();
        purpleCollider = GameObject.Find("Purple House").GetComponent<BoxCollider2D>();

        scoreText = scoreObject.GetComponent<Text>();
        timeText = timer.GetComponent<Text>();

        paused.SetActive(false);
        menu.SetActive(false);
        cont.SetActive(false);

        gamePaused = false;

        firstTimer = 7;
        secondTimer = 6;
        thirdTimer = 5;
        fourthTimer = 4;

        score = 0;

        firstCars = new GameObject[10];
        firstCarsColl = new BoxCollider2D[10];

        for(int i = 0; i < 10; i++)
        {
            firstCars[i] = GameObject.Find("Car_0" + i);
            firstCarsColl[i] = firstCars[i].GetComponent<BoxCollider2D>();
            Debug.Log(firstCars[i]);
        }

        secondCars = new GameObject[10];
        secondCarsColl = new BoxCollider2D[10];

        for (int i = 0; i < 10; i++)
        {
            secondCars[i] = GameObject.Find("Car_1" + i);
            secondCarsColl[i] = secondCars[i].GetComponent<BoxCollider2D>();
            Debug.Log(secondCars[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePaused == false)
        {
            if (firstCars[0] != null)
            {
                if (Timer.countUpTimer >= 7)
                {
                    firstCars[0].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[0] != null)
                    {
                        if (firstCarsColl[0].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[0].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[0]);

                            if (firstCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[0]);

                            if (firstCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[0]);

                            if (firstCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[0]);

                            if (firstCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[0].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[0]);

                            if (firstCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[0].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[1] != null)
            {
                if (Timer.countUpTimer >= 14)
                {
                    firstCars[1].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[1] != null)
                    {
                        if (firstCarsColl[1].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[1].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[1]);

                            if (firstCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[1]);

                            if (firstCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[1]);

                            if (firstCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[1]);

                            if (firstCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[1].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[1]);

                            if (firstCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[1].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[2] != null)
            {
                if (Timer.countUpTimer >= 21)
                {
                    firstCars[2].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[2] != null)
                    {
                        if (firstCarsColl[2].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[2].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[2]);

                            if (firstCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[2]);

                            if (firstCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[2]);

                            if (firstCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[2]);

                            if (firstCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[2].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[2]);

                            if (firstCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[2].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[3] != null)
            {
                if (Timer.countUpTimer >= 28)
                {
                    firstCars[3].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[3] != null)
                    {
                        if (firstCarsColl[3].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[3].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[3]);

                            if (firstCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[3]);

                            if (firstCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[3]);

                            if (firstCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[3]);

                            if (firstCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[3].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[3]);

                            if (firstCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[3].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[4] != null)
            {
                if (Timer.countUpTimer >= 35)
                {
                    firstCars[4].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[4] != null)
                    {
                        if (firstCarsColl[4].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[4].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[4]);

                            if (firstCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[4]);

                            if (firstCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[4]);

                            if (firstCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[4]);

                            if (firstCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[4].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[4]);

                            if (firstCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[4].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[5] != null)
            {
                if (Timer.countUpTimer >= 41)
                {
                    firstCars[5].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[5] != null)
                    {
                        if (firstCarsColl[5].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[5].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[5]);

                            if (firstCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[5]);

                            if (firstCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[5]);

                            if (firstCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[5]);

                            if (firstCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[5].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[5]);

                            if (firstCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[5].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[6] != null)
            {
                if (Timer.countUpTimer >= 47)
                {
                    firstCars[6].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[6] != null)
                    {
                        if (firstCarsColl[6].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[6].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[6]);

                            if (firstCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[6]);

                            if (firstCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[6]);

                            if (firstCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[6]);

                            if (firstCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[6].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[6]);

                            if (firstCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[6].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[7] != null)
            {
                if (Timer.countUpTimer >= 53)
                {
                    firstCars[7].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[7] != null)
                    {
                        if (firstCarsColl[7].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[7].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[7]);

                            if (firstCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[7]);

                            if (firstCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[7]);

                            if (firstCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[7]);

                            if (firstCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[7].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[7]);

                            if (firstCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[7].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[8] != null)
            {
                if (Timer.countUpTimer >= 59)
                {
                    firstCars[8].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[8] != null)
                    {
                        if (firstCarsColl[8].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[8].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[8]);

                            if (firstCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[8]);

                            if (firstCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[8]);

                            if (firstCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[8]);

                            if (firstCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[8].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[8]);

                            if (firstCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[8].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[9] != null)
            {
                if (Timer.countUpTimer >= 65)
                {
                    firstCars[9].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (firstCarsColl[9] != null)
                    {
                        if (firstCarsColl[9].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(cornerCollider.bounds))
                        {
                            firstCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (firstCarsColl[9].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(firstCars[9]);

                            if (firstCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(firstCars[9]);

                            if (firstCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(firstCars[9]);

                            if (firstCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(firstCars[9]);

                            if (firstCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (firstCarsColl[9].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(firstCars[9]);

                            if (firstCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    firstCars[9].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[0] != null)
            {
                if (Timer.countUpTimer >= 70)
                {
                    secondCars[0].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[0] != null)
                    {
                        if (secondCarsColl[0].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[0].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[0].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[0]);

                            if (secondCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[0]);

                            if (secondCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[0]);

                            if (secondCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[0]);

                            if (secondCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[0].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[0]);

                            if (secondCars[0].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[0].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[1] != null)
            {
                if (Timer.countUpTimer >= 75)
                {
                    secondCars[1].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[1] != null)
                    {
                        if (secondCarsColl[1].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[1].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[1].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[1]);

                            if (secondCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[1]);

                            if (secondCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[1]);

                            if (secondCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[1]);

                            if (secondCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[1].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[1]);

                            if (secondCars[1].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[1].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[2] != null)
            {
                if (Timer.countUpTimer >= 80)
                {
                    secondCars[2].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[2] != null)
                    {
                        if (secondCarsColl[2].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[2].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[2].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[2]);

                            if (secondCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[2]);

                            if (secondCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[2]);

                            if (secondCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[2]);

                            if (secondCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[2].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[2]);

                            if (secondCars[2].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[2].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[3] != null)
            {
                if (Timer.countUpTimer >= 85)
                {
                    secondCars[3].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[3] != null)
                    {
                        if (secondCarsColl[3].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[3].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[3].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[3]);

                            if (secondCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[3]);

                            if (secondCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[3]);

                            if (secondCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[3]);

                            if (secondCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[3].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[3]);

                            if (secondCars[3].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[3].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[4] != null)
            {
                if (Timer.countUpTimer >= 90)
                {
                    secondCars[4].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[4] != null)
                    {
                        if (secondCarsColl[4].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[4].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[4].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[4]);

                            if (secondCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[4]);

                            if (secondCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[4]);

                            if (secondCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[4]);

                            if (secondCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[4].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[4]);

                            if (secondCars[4].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[4].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[5] != null)
            {
                if (Timer.countUpTimer >= 94)
                {
                    secondCars[5].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[5] != null)
                    {
                        if (secondCarsColl[5].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[5].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[5].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[5]);

                            if (secondCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[5]);

                            if (secondCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[5]);

                            if (secondCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[5]);

                            if (secondCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[5].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[5]);

                            if (secondCars[5].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[5].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[6] != null)
            {
                if (Timer.countUpTimer >= 98)
                {
                    secondCars[6].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[6] != null)
                    {
                        if (secondCarsColl[6].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[6].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[6].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[6]);

                            if (secondCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[6]);

                            if (secondCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[6]);

                            if (secondCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[6]);

                            if (secondCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[6].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[6]);

                            if (secondCars[6].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[6].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[7] != null)
            {
                if (Timer.countUpTimer >= 102)
                {
                    secondCars[7].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[7] != null)
                    {
                        if (secondCarsColl[7].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[7].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[7].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[7]);

                            if (secondCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[7]);

                            if (secondCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[7]);

                            if (secondCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[7]);

                            if (secondCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[7].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[7]);

                            if (secondCars[7].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[7].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[8] != null)
            {
                if (Timer.countUpTimer >= 106)
                {
                    secondCars[8].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[8] != null)
                    {
                        if (secondCarsColl[8].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[8].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[8].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[8]);

                            if (secondCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[8]);

                            if (secondCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[8]);

                            if (secondCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[8]);

                            if (secondCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[8].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[8]);

                            if (secondCars[8].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[8].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (secondCars[9] != null)
            {
                if (Timer.countUpTimer >= 110)
                {
                    secondCars[9].transform.Translate(new Vector2(0, 60) * Time.deltaTime);

                    if (secondCarsColl[9] != null)
                    {
                        if (secondCarsColl[9].bounds.Intersects(btn1Collider.bounds))
                        {
                            if (btn1.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn1.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(btn2Collider.bounds))
                        {
                            if (btn2.GetComponent<Image>().sprite == Buttons.sprites[0])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn2.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(btn3Collider.bounds))
                        {
                            if (btn3.GetComponent<Image>().sprite == Buttons.sprites[1])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 180);
                            }
                            else if (btn3.GetComponent<Image>().sprite == Buttons.sprites[2])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(btn4Collider.bounds))
                        {
                            if (btn4.GetComponent<Image>().sprite == Buttons.sprites[3])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                            }
                            else if (btn4.GetComponent<Image>().sprite == Buttons.sprites[4])
                            {
                                secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 90);
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(cornerCollider.bounds))
                        {
                            secondCars[9].transform.rotation = Quaternion.Euler(0, 0, 270);
                        }

                        if (secondCarsColl[9].bounds.Intersects(blueCollider.bounds))
                        {
                            Destroy(secondCars[9]);

                            if (secondCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[0])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(greenCollider.bounds))
                        {
                            Destroy(secondCars[9]);

                            if (secondCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[1])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(orangeCollider.bounds))
                        {
                            Destroy(secondCars[9]);

                            if (secondCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[2])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(pinkCollider.bounds))
                        {
                            Destroy(secondCars[9]);

                            if (secondCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[3])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                        else if (secondCarsColl[9].bounds.Intersects(purpleCollider.bounds))
                        {
                            Destroy(secondCars[9]);

                            if (secondCars[9].GetComponent<Image>().sprite == SpriteGenerator.cars[4])
                            {
                                Score.score += 1;
                            }
                            else
                            {
                                Score.score -= 1;
                            }
                        }
                    }
                }
                else
                {
                    secondCars[9].transform.Translate(new Vector2(0, 0) * Time.deltaTime, Space.Self);
                }
            }

            if (firstCars[0] == null && firstCars[1] == null && firstCars[2] == null && firstCars[3] == null && firstCars[4] == null && firstCars[5] == null && firstCars[6] == null && firstCars[7] == null && firstCars[8] == null && firstCars[9] == null)
            {
                if (secondCars[0] == null && secondCars[1] == null && secondCars[2] == null && secondCars[3] == null && secondCars[4] == null && secondCars[5] == null && secondCars[6] == null && secondCars[7] == null && secondCars[8] == null && secondCars[9] == null)
                {
                    SceneManager.LoadScene("Complete");
                }
            }
        }
    }

    public void PauseGame()
    {
        gamePaused = true;

        buttonClick.Play();

        paused.SetActive(true);
        menu.SetActive(true);
        cont.SetActive(true);

        timer.SetActive(false);
        scoreObject.SetActive(false);
        cars.SetActive(false);
        roads.SetActive(false);
        houses.SetActive(false);
        pause.SetActive(false);
    }

    public void ContinueGame()
    {
        gamePaused = false;

        buttonClick.Play();

        paused.SetActive(false);
        menu.SetActive(false);
        cont.SetActive(false);

        timer.SetActive(true);
        scoreObject.SetActive(true);
        cars.SetActive(true);
        roads.SetActive(true);
        houses.SetActive(true);
        pause.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Navigation");

        buttonClick.Play();
    }

    private void OnEnable()
    {
        pauseButton.onClick.AddListener(PauseGame);
        contButton.onClick.AddListener(ContinueGame);
        menuButton.onClick.AddListener(BackToMenu);
    }

    private void OnDisable()
    {
        pauseButton.onClick.RemoveListener(PauseGame);
        contButton.onClick.RemoveListener(ContinueGame);
        menuButton.onClick.RemoveListener(BackToMenu);
    }
}