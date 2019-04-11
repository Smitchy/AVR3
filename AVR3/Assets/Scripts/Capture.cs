using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Capture : MonoBehaviour, IInputClickHandler {

    public delegate void ICapture();
    public ICapture iCapture;
    
    private SphereCollider col;

    private void Start()
    {
        iCapture += ToggleDragAble;
        col = GetComponent<SphereCollider>();
    }

    private void ToggleDragAble()
    {
        GetComponent<HandDraggable>().IsDraggingEnabled = true;
        GetComponent<Animator>().SetBool("captured", true);
        col.center = new Vector3(0, 0.006f, 0);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        iCapture();
    }

}
