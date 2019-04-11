using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class StartGame : MonoBehaviour, IInputHandler {

    public delegate void IStartGame();
    public IStartGame iStartGame;
    public GameObject rules;

    public bool gameStarted = false;

    private void Start()
    {
        rules.SetActive(true);
        iStartGame += DisableRules;
    }

    private void DisableRules()
    {
        rules.SetActive(false);
    }

    public void OnInputDown(InputEventData eventData)
    {
        if (!gameStarted)
        {
            iStartGame();
            gameStarted = true;
        }

    }

    public void OnInputUp(InputEventData eventData)
    {
        return;
    }
}
