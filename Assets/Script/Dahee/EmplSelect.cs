using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EmplSelect : MonoBehaviour
{



    void Start()
    {
        // 각 네모에 employee 스크립트 부여 및 변수 초기화
        GameObject[] squares = GameObject.FindGameObjectsWithTag("SelectOption"); 
        foreach (var square in squares)
        {
            Empolyee employeeScript = square.AddComponent<Empolyee>();
            employeeScript.SetRandomStats();
        }
    }

    // 클릭된 네모를 제외한 나머지 네모 삭제
    public void OnSquareClick(GameObject clickedSquare)
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("SelectOption");
        foreach (var square in squares)
        {
            if (square != clickedSquare)
            {
                Destroy(square);
            }
        }
    }
}
