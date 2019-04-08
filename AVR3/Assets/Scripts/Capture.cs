using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Capture : MonoBehaviour, IInputClickHandler {

    public delegate void ICapture();
    public ICapture iCapture;

    private bool captured;
    private CapturablesMovement movement;

    private void Start()
    {
        captured = false;
        movement = GetComponent<CapturablesMovement>();
        iCapture += MovementToggle;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        iCapture();
    }

    private void MovementToggle()
    {
        captured = !captured;
        movement.enabled = captured;
    }
}
