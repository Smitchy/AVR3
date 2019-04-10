using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem instance = null;
    public static ScoreSystem Instance{ 
        get {return instance;}
    }
    
    private int numberOfCapturables;
    private int numberAllowed;

    private int numberCaught;

    public Text score, timer;
    private int time;

    private Color defaultColor;
    public GameObject gameOver;
    public Button restartB;

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
        StartCoroutine(TimerRoutine());
        defaultColor = timer.color;

        gameOver.SetActive(false);
        restartB.gameObject.SetActive(false);

        restartB.onClick.AddListener(Restart);
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

        if (time == 0)
        {
            YouLost();
        }

    }

    void YouLost()
    {
        gameOver.SetActive(true);
        restartB.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Catch(){
        numberCaught++;
        time += 6;
    }
}
