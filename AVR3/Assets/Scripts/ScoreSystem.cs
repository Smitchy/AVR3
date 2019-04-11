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
    
    private int numberAllowed;

    private int numberCaught;
    private bool lost = false;

    public Text score, timer;
    private int time;
    public int startTime;

    private Color defaultColor;
    public GameObject gameOver;
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
        numberCaught = 0;
        time = startTime;
        
        defaultColor = timer.color;

        gameOver.SetActive(false);
        startGame.iStartGame += StartTimer;
    }

    void Restart()
    {
        lost = false;
        startGame.gameStarted = false;
        startGame.rules.SetActive(true);
        gameOver.SetActive(false);
        GameObject[] spawnAbles = GameObject.FindGameObjectsWithTag("SpawnAble");
        time = startTime;
        numberCaught = 0;
        for(int i = 0; i < spawnAbles.Length; i++)
        {
            Destroy(spawnAbles[i]);
        }
        Time.timeScale = 1f;
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
    }

    public void OnInputUp(InputEventData eventData)
    {
        return;
    }
}
