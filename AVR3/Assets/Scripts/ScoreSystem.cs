using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private int numberOfCapturables;
    private int numberAllowed;

    private int numberCaught;

    public Text score;

    void Start()
    {
        numberOfCapturables = 0;
    }

    void Update()
    {
        CountCapturables();

        score.text = "" + numberOfCapturables;

        if (numberOfCapturables >= numberAllowed)
        {
            YouLost();
        }
    }

    int CountCapturables()
    {
        numberOfCapturables += GameObject.FindGameObjectsWithTag("Bat").Length;
        return numberOfCapturables;
    }

    void YouLost()
    {

    }
}
