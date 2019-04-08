using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CapturablesMovement : MonoBehaviour, IInputClickHandler{

    public float speed;
    private float randomX;
    private float randomZ;
    private float randomY;
    private Vector3 currentRandomPos;
    private bool captured = false;


    void Start()
    {
        PickPosition();
        randomX = Random.Range(-2f, 2f);
        randomY = Random.Range(-2f, 2f);
        randomZ = Random.Range(-2f, 2f);
    }

    void PickPosition()
    {
        currentRandomPos = new Vector3(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY), Random.Range(-randomZ, randomZ));
        transform.LookAt(new Vector3(currentRandomPos.x,transform.position.y,currentRandomPos.z));
        StartCoroutine(MoveToRandomPos());

    }

    private void OnCollisionEnter(Collision other)
    {
        PickPosition();
    }


    IEnumerator MoveToRandomPos()
    {
        if (!captured)
        {
            float i = 0.0f;
            float rate = 1.0f / speed;
            Vector3 currentPos = transform.position;

            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                transform.position = Vector3.Lerp(currentPos, currentRandomPos, i);
                yield return null;
            }

            float randomFloat = Random.Range(0.0f, 1.0f); // Create %50 chance to wait
            if (randomFloat < 0.5f)
                StartCoroutine(WaitForSomeTime());
            else
            PickPosition();
        }
        
    }

    IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(0.5f);
        PickPosition();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        captured = true;
    }
}
