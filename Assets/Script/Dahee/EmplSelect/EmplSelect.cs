using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EmplSelect : MonoBehaviour
{



    void Start()
    {
        // �� �׸� employee ��ũ��Ʈ �ο� �� ���� �ʱ�ȭ
        GameObject[] squares = GameObject.FindGameObjectsWithTag("SelectOption"); 
        foreach (var square in squares)
        {
            Empolyee employeeScript = square.AddComponent<Empolyee>();
            employeeScript.SetRandomStats();
        }


    }



    //Ŭ���� �׸� �����
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
