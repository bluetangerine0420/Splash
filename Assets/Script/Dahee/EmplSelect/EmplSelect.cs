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
    public Characters charactersScript;

    public UnityEngine.UI.Text strangeText;
    public UnityEngine.UI.Text intelligentText;
    public UnityEngine.UI.Text luckText;
    public UnityEngine.UI.Text hpText;
    public UnityEngine.UI.Text mentalText;

    public Employee employee;


    void Start()
    {
        //각 네모에 employee 스크립트 부여 및 변수 초기화
        GameObject[] squares = GameObject.FindGameObjectsWithTag("SelectOption");
        foreach (var square in squares)
        {
            Employee employeeScript = square.AddComponent<Employee>();
            employeeScript.SetRandomStats();

            if (square.activeSelf)
            {
                employee = employeeScript;
                UpdateStatsText(employee.Atk, employee.Int, employee.Luck, (int)employee.Hp, employee.Mental);
            }

            
        }


  
    }

    public void UpdateStatsText(int strange, int intelligent, int luck, int hp, int mental)
    {
        strangeText.text = "Strange: " + strange.ToString();
        intelligentText.text = "Intelligent: " + intelligent.ToString();
        luckText.text = "Luck: " + luck.ToString();
        hpText.text = "HP: " + hp.ToString();
        mentalText.text = "Mental: " + mental.ToString();
    }

    //클릭된 네모만 남기기
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

        charactersScript.ChangeSpriteWithFade();

    
      


    }


}
