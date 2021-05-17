using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnShape : MonoBehaviour
{
    public static GameObject[] shapes;
    private GameObject timer, scoreObject, pause, paused, cont, menu, shapeParent;
    public static int score;
    private int randomIndex;
    public static float countDownTimer, delayTimer;
    private Button[] buttons;
    public Button pauseButton, contButton, menuButton;
    private Text timeText, scoreText;
    public static bool gamePaused;
    private AudioSource buttonClick, shapeClick;
    public AudioClip buttonClip, shapeClip;

    void Start()
    {
        score = 0;
        delayTimer = 4;
        countDownTimer = 90;

        buttonClick = GameObject.Find("SFX 01").GetComponent<AudioSource>();
        shapeClick = GameObject.Find("SFX 02").GetComponent<AudioSource>();

        timer = GameObject.Find("Time");
        scoreObject = GameObject.Find("Score");
        paused = GameObject.Find("Paused");
        pause = GameObject.Find("Pause Button");
        cont = GameObject.Find("Continue Button");
        menu = GameObject.Find("Main Menu Button");
        shapeParent = GameObject.Find("Shapes");

        timeText = timer.GetComponent<Text>();
        scoreText = scoreObject.GetComponent<Text>();

        shapes = new GameObject[16];
        shapes[0] = GameObject.Find("Shapes/Circle");
        shapes[1] = GameObject.Find("Shapes/Crescent");
        shapes[2] = GameObject.Find("Shapes/Decagon");
        shapes[3] = GameObject.Find("Shapes/Heart");
        shapes[4] = GameObject.Find("Shapes/Heptagon");
        shapes[5] = GameObject.Find("Shapes/Hexagon");
        shapes[6] = GameObject.Find("Shapes/Nonagon");
        shapes[7] = GameObject.Find("Shapes/Octagon");
        shapes[8] = GameObject.Find("Shapes/Parallelogram");
        shapes[9] = GameObject.Find("Shapes/Pentagon");
        shapes[10] = GameObject.Find("Shapes/Rhombus");
        shapes[11] = GameObject.Find("Shapes/Septagon");
        shapes[12] = GameObject.Find("Shapes/Square");
        shapes[13] = GameObject.Find("Shapes/Star");
        shapes[14] = GameObject.Find("Shapes/Trapezium");
        shapes[15] = GameObject.Find("Shapes/Triangle");

        buttons = new Button[16];
        buttons[0] = shapes[0].GetComponent<Button>();
        buttons[1] = shapes[1].GetComponent<Button>();
        buttons[2] = shapes[2].GetComponent<Button>();
        buttons[3] = shapes[3].GetComponent<Button>();
        buttons[4] = shapes[4].GetComponent<Button>();
        buttons[5] = shapes[5].GetComponent<Button>();
        buttons[6] = shapes[6].GetComponent<Button>();
        buttons[7] = shapes[7].GetComponent<Button>();
        buttons[8] = shapes[8].GetComponent<Button>();
        buttons[9] = shapes[9].GetComponent<Button>();
        buttons[10] = shapes[10].GetComponent<Button>();
        buttons[11] = shapes[11].GetComponent<Button>();
        buttons[12] = shapes[12].GetComponent<Button>();
        buttons[13] = shapes[13].GetComponent<Button>();
        buttons[14] = shapes[14].GetComponent<Button>();
        buttons[15] = shapes[15].GetComponent<Button>();

        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i].SetActive(false);
        }

        paused.SetActive(false);
        cont.SetActive(false);
        menu.SetActive(false);
        shapeParent.SetActive(true);

        gamePaused = false;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        if(gamePaused == false)
        {
            countDownTimer -= Time.deltaTime;
            delayTimer -= Time.deltaTime;

            if (shapes[0].activeSelf == true)
            {
                shapes[0].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[0].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[1].activeSelf == true)
            {
                shapes[1].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[1].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[2].activeSelf == true)
            {
                shapes[2].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[2].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[3].activeSelf == true)
            {
                shapes[3].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[3].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[4].activeSelf == true)
            {
                shapes[4].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[4].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[5].activeSelf == true)
            {
                shapes[5].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[5].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[6].activeSelf == true)
            {
                shapes[6].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[6].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[7].activeSelf == true)
            {
                shapes[7].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[7].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[8].activeSelf == true)
            {
                shapes[8].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[8].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[9].activeSelf == true)
            {
                shapes[9].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[9].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[10].activeSelf == true)
            {
                shapes[10].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[10].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[11].activeSelf == true)
            {
                shapes[11].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[11].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[12].activeSelf == true)
            {
                shapes[12].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[12].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[13].activeSelf == true)
            {
                shapes[13].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[13].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[14].activeSelf == true)
            {
                shapes[14].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[14].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (shapes[15].activeSelf == true)
            {
                shapes[15].transform.localScale += new Vector3(0.005f, 0.005f, 0);
            }
            else
            {
                shapes[15].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        DisplayTime(countDownTimer);

        if(delayTimer <= 0)
        {
            randomIndex = Random.Range(0, shapes.Length);
            shapes[randomIndex].SetActive(true);
            shapes[randomIndex].transform.position = new Vector3(Random.Range(150, 1130), Random.Range(150, 580));

            if (countDownTimer >= 60 && countDownTimer < 90)
            {
                delayTimer = 2f;
            }
            else if (countDownTimer >= 30 && countDownTimer < 60)
            {
                delayTimer = 1.75f;
            }
            else if (countDownTimer > 0 && countDownTimer < 30)
            {
                delayTimer = 1.5f;
            }
            else if(countDownTimer <= 0)
            {
                if(Leaderboard.scores.Count < 5)
                {
                    Leaderboard.scores.Add(score);
                }

                SceneManager.LoadScene("Complete");
            }
        }
    }

    public void PauseGame()
    {
        buttonClick.Play();

        gamePaused = true;

        paused.SetActive(true);
        menu.SetActive(true);
        cont.SetActive(true);

        timer.SetActive(false);
        scoreObject.SetActive(false);
        shapeParent.SetActive(false);
        pause.SetActive(false);
    }

    public void ContinueGame()
    {
        buttonClick.Play();

        gamePaused = false;

        paused.SetActive(false);
        menu.SetActive(false);
        cont.SetActive(false);

        timer.SetActive(true);
        scoreObject.SetActive(true);
        shapeParent.SetActive(true);
        pause.SetActive(true);
    }

    public void BackToMenu()
    {
        buttonClick.Play();

        SceneManager.LoadScene("Navigation");
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(countDownTimer / 60);
        float seconds = Mathf.FloorToInt(countDownTimer % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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