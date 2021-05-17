using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MAnswer : MonoBehaviour
{
    private GameObject timer, question, gameOver, inputField, aButton, fButton, nButton, yButton, ready, emptyAnswer, paused, pause, cont, menu, answers, correctAnswers, inputAnswers;
    private float countDownTimer, nextSceneTimer, temp;
    private Text timeText, gameOverText, inputText, answerText;
    private List<string> userInput;
    public InputField input;
    public Button answerButton, finishedButton, yesButton, noButton, pauseButton, contButton, menuButton;
    private bool gamePaused, timerRunning;
    private AudioSource buttonClick;
    public AudioClip buttonClip;

    // Start is called before the first frame update
    void Start()
    {
        buttonClick = GameObject.Find("SFX").GetComponent<AudioSource>();
        buttonClick.clip = buttonClip;

        nextSceneTimer = 5;

        userInput = new List<string>();

        timer = GameObject.Find("Time");
        question = GameObject.Find("Question");
        gameOver = GameObject.Find("Game Over");
        inputField = GameObject.Find("InputField");
        aButton = GameObject.Find("Answer Button");
        fButton = GameObject.Find("Finish Button");
        nButton = GameObject.Find("No Button");
        yButton = GameObject.Find("Yes Button");
        ready = GameObject.Find("Ready");
        emptyAnswer = GameObject.Find("Empty Answer");
        paused = GameObject.Find("Paused");
        pause = GameObject.Find("Pause Button");
        cont = GameObject.Find("Continue Button");
        menu = GameObject.Find("Main Menu Button");
        answers = GameObject.Find("Answer Text");
        correctAnswers = GameObject.Find("Correct Answers");
        inputAnswers = GameObject.Find("User Input");

        inputText = GameObject.Find("User Input").GetComponent<Text>();
        answerText = GameObject.Find("Correct Answers").GetComponent<Text>();
        timeText = timer.GetComponent<Text>();
        gameOverText = gameOver.GetComponent<Text>();

        ready.SetActive(false);
        nButton.SetActive(false);
        yButton.SetActive(false);
        emptyAnswer.SetActive(false);
        answers.SetActive(false);
 
        if (SceneName.previousLevel == "MLevel1")
        {
            countDownTimer = 90;
        }
        else if (SceneName.previousLevel == "MLevel2")
        {
            countDownTimer = 80;

            inputText.fontSize = 70;
            answerText.fontSize = 70;
        }
        else if (SceneName.previousLevel == "MLevel3")
        {
            countDownTimer = 70;

            inputText.fontSize = 60;
            answerText.fontSize = 60;
        }
        else if (SceneName.previousLevel == "MLevel4")
        {
            countDownTimer = 60;

            inputText.fontSize = 50;
            answerText.fontSize = 50;
        }

        paused.SetActive(false);
        cont.SetActive(false);
        menu.SetActive(false);

        gamePaused = false;
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePaused == false)
        {
            if (timeText != null)
            {
                if(timerRunning == true)
                {
                    countDownTimer -= Time.deltaTime;
                    DisplayTime(countDownTimer);
                }
            }

            if (countDownTimer <= 0)
            {
                timer.SetActive(false);
                question.SetActive(false);
                inputField.SetActive(false);
                aButton.SetActive(false);

                gameOverText.text = string.Format("Game Over!");

                nextSceneTimer -= Time.deltaTime;
                if (nextSceneTimer <= 0)
                {
                    SceneManager.LoadScene("Navigation");
                }
            }
        }
        else if(gamePaused == true)
        {
            Debug.Log(countDownTimer);
        }
    }

    public void StoreAnswers()
    {
        buttonClick.Play();

        if (input.text != "")
        {
            emptyAnswer.SetActive(false);
            Debug.Log(input.text);
            userInput.Add(input.text);
            input.text = "";
        }
        else
        {
            emptyAnswer.SetActive(true);
        }
    }

    public void FinishGame()
    {
        buttonClick.Play();

        if (gameOverText.text == "")
        {
            if (question.activeSelf == true && inputField.activeSelf == true && aButton.activeSelf == true)
            {
                ready.SetActive(true);
                nButton.SetActive(true);
                yButton.SetActive(true);
                fButton.SetActive(false);
            }
            else
            {
                if (SceneName.previousLevel == "MLevel1")
                {
                    SceneManager.LoadScene("MLevel2");
                }
                else if (SceneName.previousLevel == "MLevel2")
                {
                    SceneManager.LoadScene("MLevel3");
                }
                else if (SceneName.previousLevel == "MLevel3")
                {
                    SceneManager.LoadScene("MLevel4");
                }
                else if (SceneName.previousLevel == "MLevel4")
                {
                    SceneManager.LoadScene("Complete");
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Navigation");
        }
    }

    public void BackToGame()
    {
        buttonClick.Play();

        ready.SetActive(false);
        nButton.SetActive(false);
        yButton.SetActive(false);
        fButton.SetActive(true);
    }

    public void ShowAnswers()
    {
        buttonClick.Play();

        question.SetActive(false);
        inputField.SetActive(false);
        timer.SetActive(false);
        aButton.SetActive(false);
        ready.SetActive(false);
        nButton.SetActive(false);
        yButton.SetActive(false);
        fButton.SetActive(true);
        answers.SetActive(true);

        inputText.text = "Your answers:\n";

        foreach(var item in userInput)
        {
            inputText.text += item + "\n";
        }

        answerText.text = "Correct answers:\n";

        foreach(var item in MLevels.objectNames)
        {
            answerText.text += item + "\n";
        }
    }

    public void PauseGame()
    {
        gamePaused = true;

        buttonClick.Play();

        paused.SetActive(true);
        menu.SetActive(true);
        cont.SetActive(true);

        question.SetActive(false);
        inputField.SetActive(false);
        timer.SetActive(false);
        aButton.SetActive(false);
        fButton.SetActive(false);
        timer.SetActive(false);
        pause.SetActive(false);
        correctAnswers.SetActive(false);
        inputAnswers.SetActive(false);

        timerRunning = false;
    }

    public void ContinueGame()
    {
        gamePaused = false;

        buttonClick.Play();

        paused.SetActive(false);
        menu.SetActive(false);
        cont.SetActive(false);

        if(answers.activeSelf == false)
        {
            question.SetActive(true);
            inputField.SetActive(true);
            timer.SetActive(true);
            aButton.SetActive(true);
            fButton.SetActive(true);
            timer.SetActive(true);
            pause.SetActive(true);

            timerRunning = true;
        }
        else if(answers.activeSelf == true)
        {
            correctAnswers.SetActive(true);
            inputAnswers.SetActive(true);
            fButton.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Navigation");

        buttonClick.Play();
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(countDownTimer / 60);
        float seconds = Mathf.FloorToInt(countDownTimer % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnEnable()
    {
        answerButton.onClick.AddListener(StoreAnswers);
        finishedButton.onClick.AddListener(FinishGame);
        noButton.onClick.AddListener(BackToGame);
        yesButton.onClick.AddListener(ShowAnswers);
        pauseButton.onClick.AddListener(PauseGame);
        contButton.onClick.AddListener(ContinueGame);
        menuButton.onClick.AddListener(BackToMenu);
    }

    private void OnDisable()
    {
        answerButton.onClick.RemoveListener(StoreAnswers);
        finishedButton.onClick.RemoveListener(FinishGame);
        noButton.onClick.RemoveListener(BackToGame);
        yesButton.onClick.RemoveListener(ShowAnswers);
        pauseButton.onClick.RemoveListener(PauseGame);
        contButton.onClick.RemoveListener(ContinueGame);
        menuButton.onClick.RemoveListener(BackToMenu);
    }
}
