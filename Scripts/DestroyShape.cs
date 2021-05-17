using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShape : MonoBehaviour
{
    public static float circleTimer, crescentTimer, decagonTimer, heartTimer, heptagonTimer, hexagonTimer, nonagonTimer, octagonTimer, parallelogramTimer, pentagonTimer, rhombusTimer, septagonTimer, squareTimer, starTimer, trapeziumTimer, triangleTimer;
    private bool circleClicked, crescentClicked, decagonClicked, heartClicked, heptagonClicked, hexagonClicked, nonagonClicked, octagonClicked, parallelogramClicked, pentagonClicked, rhombusClicked, septagonClicked, squareClicked, starClicked, trapeziumClicked, triangleClicked;
    private AudioSource buttonClick, shapeClick;
    public AudioClip buttonClip, shapeClip;

    private void Start()
    {
        buttonClick = GameObject.Find("SFX 01").GetComponent<AudioSource>();
        shapeClick = GameObject.Find("SFX 02").GetComponent<AudioSource>();

        buttonClick.clip = buttonClip;
        shapeClick.clip = shapeClip;

        circleClicked = false;
        crescentClicked = false;
        decagonClicked = false;
        heartClicked = false;
        heptagonClicked = false;
        hexagonClicked = false;
        nonagonClicked = false;
        octagonClicked = false;
        parallelogramClicked = false;
        pentagonClicked = false;
        rhombusClicked = false;
        septagonClicked = false;
        squareClicked = false;
        starClicked = false;
        trapeziumClicked = false;
        triangleClicked = false;

        circleTimer = 3;
        crescentTimer = 3;
        decagonTimer = 3;
        heartTimer = 3;
        heptagonTimer = 3;
        hexagonTimer = 3;
        nonagonTimer = 3;
        octagonTimer = 3;
        parallelogramTimer = 3;
        pentagonTimer = 3;
        rhombusTimer = 3;
        septagonTimer = 3;
        squareTimer = 3;
        starTimer = 3;
        trapeziumTimer = 3;
        triangleTimer = 3;
    }

    void Update()
    {
        if(SpawnShape.gamePaused == false)
        {
            if (SpawnShape.shapes[0].activeSelf == true)
            {
                circleTimer -= Time.deltaTime;

                if (circleTimer <= 0 || circleClicked == true)
                {
                    if (circleTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[0].SetActive(false);
                    circleTimer = 3;
                    circleClicked = false;
                }
            }

            if (SpawnShape.shapes[1].activeSelf == true)
            {
                crescentTimer -= Time.deltaTime;

                if (crescentTimer <= 0 || crescentClicked == true)
                {
                    if (crescentTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[1].SetActive(false);
                    crescentTimer = 3;
                    crescentClicked = false;
                }
            }

            if (SpawnShape.shapes[2].activeSelf == true)
            {
                decagonTimer -= Time.deltaTime;

                if (decagonTimer <= 0 || decagonClicked == true)
                {
                    if (decagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[2].SetActive(false);
                    decagonTimer = 3;
                    decagonClicked = false;
                }
            }

            if (SpawnShape.shapes[3].activeSelf == true)
            {
                heartTimer -= Time.deltaTime;

                if (heartTimer <= 0 || heartClicked == true)
                {
                    if (heartTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[3].SetActive(false);
                    heartTimer = 3;
                    heartClicked = false;
                }
            }

            if (SpawnShape.shapes[4].activeSelf == true)
            {
                heptagonTimer -= Time.deltaTime;

                if (heptagonTimer <= 0 || heptagonClicked == true)
                {
                    if (heptagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[4].SetActive(false);
                    heptagonTimer = 3;
                    heptagonClicked = false;
                }
            }

            if (SpawnShape.shapes[5].activeSelf == true)
            {
                hexagonTimer -= Time.deltaTime;

                if (hexagonTimer <= 0 || hexagonClicked == true)
                {
                    if (hexagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[5].SetActive(false);
                    hexagonTimer = 3;
                    hexagonClicked = false;
                }
            }

            if (SpawnShape.shapes[6].activeSelf == true)
            {
                nonagonTimer -= Time.deltaTime;

                if (nonagonTimer <= 0 || nonagonClicked == true)
                {
                    if (nonagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[6].SetActive(false);
                    nonagonTimer = 3;
                    nonagonClicked = false;
                }
            }

            if (SpawnShape.shapes[7].activeSelf == true)
            {
                octagonTimer -= Time.deltaTime;

                if (octagonTimer <= 0 || octagonClicked == true)
                {
                    if (octagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[7].SetActive(false);
                    octagonTimer = 3;
                    octagonClicked = false;
                }
            }

            if (SpawnShape.shapes[8].activeSelf == true)
            {
                parallelogramTimer -= Time.deltaTime;

                if (parallelogramTimer <= 0 || parallelogramClicked == true)
                {
                    if (parallelogramTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[8].SetActive(false);
                    parallelogramTimer = 3;
                    parallelogramClicked = false;
                }
            }

            if (SpawnShape.shapes[9].activeSelf == true)
            {
                pentagonTimer -= Time.deltaTime;

                if (pentagonTimer <= 0 || pentagonClicked == true)
                {
                    if (pentagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[9].SetActive(false);
                    pentagonTimer = 3;
                    pentagonClicked = false;
                }
            }

            if (SpawnShape.shapes[10].activeSelf == true)
            {
                rhombusTimer -= Time.deltaTime;

                if (rhombusTimer <= 0 || rhombusClicked == true)
                {
                    if (rhombusTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[10].SetActive(false);
                    rhombusTimer = 3;
                    rhombusClicked = false;
                }
            }

            if (SpawnShape.shapes[11].activeSelf == true)
            {
                septagonTimer -= Time.deltaTime;

                if (septagonTimer <= 0 || septagonClicked == true)
                {
                    if (septagonTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[11].SetActive(false);
                    septagonTimer = 3;
                    septagonClicked = false;
                }
            }

            if (SpawnShape.shapes[12].activeSelf == true)
            {
                squareTimer -= Time.deltaTime;

                if (squareTimer <= 0 || squareClicked == true)
                {
                    if (squareTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[12].SetActive(false);
                    squareTimer = 3;
                    squareClicked = false;
                }
            }

            if (SpawnShape.shapes[13].activeSelf == true)
            {
                starTimer -= Time.deltaTime;

                if (starTimer <= 0 || starClicked == true)
                {
                    if (starTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[13].SetActive(false);
                    starTimer = 3;
                    starClicked = false;
                }
            }

            if (SpawnShape.shapes[14].activeSelf == true)
            {
                trapeziumTimer -= Time.deltaTime;

                if (trapeziumTimer <= 0 || trapeziumClicked == true)
                {
                    if (trapeziumTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[14].SetActive(false);
                    trapeziumTimer = 3;
                    trapeziumClicked = false;
                }
            }

            if (SpawnShape.shapes[15].activeSelf == true)
            {
                triangleTimer -= Time.deltaTime;

                if (triangleTimer <= 0 || triangleClicked == true)
                {
                    if (triangleTimer > 0)
                    {
                        shapeClick.Play();
                        SpawnShape.score += 1;
                    }

                    SpawnShape.shapes[15].SetActive(false);
                    triangleTimer = 3;
                    triangleClicked = false;
                }
            }
        }
    }

    public void ClickCircle()
    {
        circleClicked = true;
    }

    public void ClickCrescent()
    {
        crescentClicked = true;
    }

    public void ClickDecagon()
    {
        decagonClicked = true;
    }

    public void ClickHeart()
    {
        heartClicked = true;
    }

    public void ClickHeptagon()
    {
        heptagonClicked = true;
    }

    public void ClickHexagon()
    {
        hexagonClicked = true;
    }

    public void ClickNonagon()
    {
        nonagonClicked = true;
    }

    public void ClickOctagon()
    {
        octagonClicked = true;
    }

    public void ClickParallelogram()
    {
        parallelogramClicked = true;
    }

    public void ClickPentagon()
    {
        pentagonClicked = true;
    }

    public void ClickRhombus()
    {
        rhombusClicked = true;
    }

    public void ClickSeptagon()
    {
        septagonClicked = true;
    }

    public void ClickSquare()
    {
        squareClicked = true;
    }

    public void ClickStar()
    {
        starClicked = true;
    }

    public void ClickTrapezium()
    {
        trapeziumClicked = true;
    }

    public void ClickTriangle()
    {
        triangleClicked = true;
    }
}