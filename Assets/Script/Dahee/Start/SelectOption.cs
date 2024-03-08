using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectOption : MonoBehaviour
{
    public Transform[] targetPositions;
    public float moveSpeed = 2.0f;

    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float startTime;
    private int targetIndex = 0;

    public GameObject objectToActivate;


    void Start()
    {
        startPosition = transform.position;
        SetTargetPosition();
    }

    void Update()
    {
        switch (targetIndex)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("SampleScene");
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("SampleScene");
                }
                break;
            default:
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
                {
                         
                    ActivateObject();
                    
                }
                break;
        }

        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / Vector3.Distance(startPosition, targetPosition);
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                isMoving = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToNextPosition();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveToPreviousPosition();
        }

      
        if (Input.GetKeyDown(KeyCode.X))
        {
            objectToActivate.SetActive(false);
        }
    }

    private void MoveToNextPosition()
    {
        targetIndex = (targetIndex + 1) % targetPositions.Length;
        SetTargetPosition();

        isMoving = true;
        startTime = Time.time;
    }

    private void MoveToPreviousPosition()
    {
        targetIndex--;
        if (targetIndex < 0)
        {
            targetIndex = targetPositions.Length - 1;
        }
        SetTargetPosition();
        Debug.Log(targetIndex);

        isMoving = true;
        startTime = Time.time;
    }

    private void SetTargetPosition()
    {
        targetPosition = targetPositions[targetIndex].position;
        if (targetIndex == 0)
        {
            targetPosition = startPosition;
        }
    }

    public void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}
