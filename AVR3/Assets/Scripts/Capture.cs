using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Capture : MonoBehaviour, IInputClickHandler {

    public delegate void ICapture();
    public ICapture iCapture;

    private bool captured;
    private CapturablesMovement movement;

    private void Start()
    {
        captured = false;
        movement = GetComponent<CapturablesMovement>();
        iCapture += ToggleDragAble;
    }

    private void ToggleDragAble()
    {
        GetComponent<HandDraggable>().IsDraggingEnabled = true;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        iCapture();
    }

}
