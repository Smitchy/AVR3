using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class OpenChest : MonoBehaviour, IInputHandler {

	public Animator anim;

    public void OnInputDown(InputEventData eventData)
    {
        anim.SetBool("open", true);
    }

    public void OnInputUp(InputEventData eventData)
    {
        anim.SetBool("open", false);
    }

}
