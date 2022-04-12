using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Transform targetLeft, targetRight;

    public Text debugText;

    public float moveTime = 0f;

    public float moveTowardSpeedLinear = 0f;

    public bool goingLeft = true;

    public bool isRunning;

    Coroutine currentRoutine;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isRunning)
        {
            if (goingLeft)
            {
                //goingLeft = false;
                if(isRunning) StopCoroutine(currentRoutine);
                currentRoutine = StartCoroutine(CameraMove(targetLeft.position, moveTime));

                PlayerTyping._pTyping.PlayerCanType = !PlayerTyping._pTyping.PlayerCanType;
            }
            else
            {
                //goingLeft = true;
                if(isRunning) StopCoroutine(currentRoutine);
                currentRoutine = StartCoroutine(CameraMove(targetRight.position, moveTime));

                PlayerTyping._pTyping.PlayerCanType = !PlayerTyping._pTyping.PlayerCanType;
            }
        }

        /*if (Input.GetKeyDown(KeyCode.M) && !isRunning)
        {
            StartCoroutine(MoveToSpot());
        }*/
    }

    IEnumerator CameraMove(Vector3 targetPos, float duration)
    {
        isRunning = true;

        float elapsedTime = 0f;

        Vector3 startPos = transform.position;

        Vector3 oldPos;

        float speed = 0f;

        while (elapsedTime < duration)
        {
            oldPos = transform.position;

            float t = elapsedTime / duration;

            if (Input.GetKeyDown(KeyCode.Space) && elapsedTime > 0)
            {
                if (goingLeft)
                {
                    goingLeft = false;
                    startPos = targetLeft.position;
                    targetPos = targetRight.position;
                    elapsedTime = duration - elapsedTime;
                    t = elapsedTime / duration;
                }
                else
                {
                    goingLeft = true;
                    startPos = targetRight.position;
                    targetPos = targetLeft.position;
                    elapsedTime = duration - elapsedTime;
                    t = elapsedTime / duration;
                }
            }

            t = t * t * (3f - 2f * t); // Smoothstep

            //t = t * t; // Ease-in

            transform.position = Vector3.Lerp(startPos, targetPos, t);

            speed = Vector3.Distance(oldPos, transform.position) * 100;

            float remaining = duration - elapsedTime;
            debugText.text = "REMAINING TRAVEL TIME: " + remaining.ToString("F2") + "\nTRAVEL SPEED: " + speed.ToString("F2");

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = targetPos;
        goingLeft = !goingLeft;
        isRunning = false;
    }

    IEnumerator MoveToSpot()
    {
        isRunning = true;
        Vector3 target;
        Vector3 oldpos;
        float speed;
        target = goingLeft ? targetLeft.position : targetRight.position;
        goingLeft = !goingLeft;
        //Debug.Log(target);

        while (transform.position != target)
        {
            oldpos = transform.position;

            if (Input.GetKeyDown(KeyCode.M)) goingLeft = !goingLeft;

            target = goingLeft ? targetLeft.position : targetRight.position;

            transform.position = Vector3.MoveTowards(transform.position, target, moveTowardSpeedLinear * Time.deltaTime);

            speed = Vector3.Distance(oldpos, transform.position) * 100f;

            float remaining = Vector3.Distance(transform.position, target) / moveTowardSpeedLinear;

            debugText.text = "REMAINING TRAVEL TIME: " + remaining.ToString("F2") + "\nTRAVEL SPEED: " + speed.ToString("F2");
            yield return null;
        }
        isRunning = false;
        goingLeft = !goingLeft;
    }
}