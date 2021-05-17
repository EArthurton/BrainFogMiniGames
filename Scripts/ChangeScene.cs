using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button menuButton, cInstructions, mInstructions, sInstructions, cStart, mStart, sStart, cont, paused, options, leaderboard;
    private AudioSource buttonClick;
    public AudioClip buttonClip;

    private void Start()
    {
        buttonClick = GameObject.Find("SFX").GetComponent<AudioSource>();
        buttonClick.clip = buttonClip;
    }

    public void StartConcentration()
    {
        SceneManager.LoadScene("ConcentrationGame");

        buttonClick.Play();
    }

    public void StartMemory()
    {
        SceneManager.LoadScene("MLevel1");

        buttonClick.Play();
    }

    public void StartSpeed()
    {
        SceneManager.LoadScene("SpeedGame");

        buttonClick.Play();
    }

    public void ConcentrationInstructions()
    {
        SceneManager.LoadScene("CInstructions");

        buttonClick.Play();
    }

    public void MemoryInstructions()
    {
        SceneManager.LoadScene("MInstructions");

        buttonClick.Play();
    }

    public void SpeedInstructions()
    {
        SceneManager.LoadScene("SInstructions");

        buttonClick.Play();
    }

    public void MainMenu()
    {;
        SceneManager.LoadScene("Navigation");

        buttonClick.Play();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");

        buttonClick.Play();
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");

        buttonClick.Play();
    }

    public void OnEnable()
    {
        menuButton.onClick.AddListener(MainMenu);
        cInstructions.onClick.AddListener(ConcentrationInstructions);
        mInstructions.onClick.AddListener(MemoryInstructions);
        sInstructions.onClick.AddListener(SpeedInstructions);
        cStart.onClick.AddListener(StartConcentration);
        mStart.onClick.AddListener(StartMemory);
        sStart.onClick.AddListener(StartSpeed);
        options.onClick.AddListener(Options);
        leaderboard.onClick.AddListener(Leaderboard);
    }

    public void OnDisable()
    {
        menuButton.onClick.RemoveListener(MainMenu);
        cInstructions.onClick.RemoveListener(ConcentrationInstructions);
        mInstructions.onClick.RemoveListener(MemoryInstructions);
        sInstructions.onClick.RemoveListener(SpeedInstructions);
        cStart.onClick.RemoveListener(StartConcentration);
        mStart.onClick.RemoveListener(StartMemory);
        sStart.onClick.RemoveListener(StartSpeed);
        options.onClick.RemoveListener(Options);
        leaderboard.onClick.RemoveListener(Leaderboard);
    }
}
