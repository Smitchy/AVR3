using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStorage : MonoBehaviour
{

    private GameObject chest;
    private bool isChestAssigned = false;

    public Animator anim;
    public Animation openChest;
    public Animation closeChest;

	void Start ()
    {
    }
	
	void Update () {

        if (!isChestAssigned)
        {
            chest = GameObject.FindGameObjectWithTag("chest");
            anim = chest.GetComponent<Animator>();
            isChestAssigned = true;
        }

	}
}
