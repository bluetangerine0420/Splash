using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class EmplSelect : MonoBehaviour
{
    public Transform desiredPosition; 
    public float moveSpeed = 5f; 
    private bool isMoving = false;

    private Transform selectedSquare;

    void Start()
    {
        //�� �׸� employee ��ũ��Ʈ �ο� �� ���� �ʱ�ȭ
        GameObject[] squares = GameObject.FindGameObjectsWithTag("SelectOption");
        foreach (var square in squares)
        {
            Employee employeeScript = square.AddComponent<Employee>();
            employeeScript.SetRandomStats();
        }

  
    }

    //Ŭ���� �׸� �����
    public void OnSquareClick(GameObject clickedSquare)
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("SelectOption");
        foreach (var square in squares)
        {
            if (square == clickedSquare)
            {
                selectedSquare = clickedSquare.transform;
            }
            else
            {
                square.SetActive(false);
            }
        }
        MoveSelectedSquareToDesiredPosition();
    }

  
    private void MoveSelectedSquareToDesiredPosition()
    {
        if (selectedSquare != null && desiredPosition != null && !isMoving)
        {
            StartCoroutine(MoveCoroutine());
        }
    }

 
    private IEnumerator MoveCoroutine()
    {
        isMoving = true;
        while (Vector3.Distance(selectedSquare.position, desiredPosition.position) > 0.05f)
        {
            selectedSquare.position = Vector3.MoveTowards(selectedSquare.position, desiredPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;

    }


}
