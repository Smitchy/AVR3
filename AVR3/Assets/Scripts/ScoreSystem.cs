using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class ScoreSystem : MonoBehaviour, IInputHandler{

    private static ScoreSystem instance = null;
    public static ScoreSystem Instance{ 
        get {return instance;}
    }
    
    private int numberOfCapturables;
    private int numberAllowed;

    private int numberCaught;
    private bool lost = false;

    public Text score, timer;
    private int time;

    private Color defaultColor;
    public GameObject gameOver;
    public Button restartB;
    public StartGame startGame;

    void Awake() {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        numberOfCapturables = 0;
        numberCaught = 0;
        time = 30;
        
        defaultColor = timer.color;

        gameOver.SetActive(false);
        startGame.iStartGame += StartTimer;
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator TimerRoutine()
    {
        while(time > 0)
        {
            time--;
            yield return new WaitForSeconds(1);
        }
        if (time == 0)
        {
            YouLost();
        }
    }

    void Update()
    {

        score.text = "Caught: "+numberCaught;
        
        if ((time - (time / 60) * 60) < 10)
        {
            timer.text = "Time left: 0" + (time / 60) + ":0" + (time - (time / 60) * 60);
        }
        else
        {
            timer.text = "Time left: 0" + (time / 60) + ":" + (time - (time / 60) * 60);
        }

        if (time < 10)
        {
            timer.color = Color.red;
            score.color=Color.red;
        }
        else
        {
            timer.color = defaultColor;
            score.color = defaultColor;
        }
    }

    void YouLost()
    {
        gameOver.SetActive(true);
        restartB.gameObject.SetActive(true);
        Time.timeScale = 0f;
        lost = true;
    }

    public void Catch(){
        numberCaught++;
        time += 6;
    }

    private void StartTimer()
    {
        StartCoroutine(TimerRoutine());
    }

    public void OnInputDown(InputEventData eventData)
    {
        if (lost) Restart();
        lost = false;
    }

    public void OnInputUp(InputEventData eventData)
    {
        return;
    }
}
