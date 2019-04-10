using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Text score;

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
        numberOfCapturables = 0;
        numberCaught = 0;
    }

    void Update()
    {

        score.text = "Caught: "+numberCaught;

        if (numberOfCapturables >= numberAllowed)
        {
            YouLost();
        }
    }


    void YouLost()
    {

    }

    public void Catch(){
        numberCaught++;
    }
}
