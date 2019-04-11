using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawn : MonoBehaviour{

    public GameObject chest;
    public Transform cameraPos, cursorPos;
    public StartGame startGame;

    private void Start()
    {
        startGame.iStartGame += SpawnChest;
    }

    private void SpawnChest()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraPos.position, cursorPos.position - cameraPos.position, out hit))
        {
            Instantiate(chest, hit.point + new Vector3(0, 0.185f, 0), Quaternion.Euler(0f, 180f, 0f));
        }
    }

}
