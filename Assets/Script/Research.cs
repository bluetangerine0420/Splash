using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Research : MonoBehaviour
{
    DNAnode[] Nodes;
    GameObject[] SplashUi;
    int Cur_Node_Num = 0;
    struct Sums
    {
        public int NodeValue;
        public string Name;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (Node_Check())
        {
            case "Ray":
                SplashUi[0].SetActive(true);
                break;
            case "Starfish":
                SplashUi[1].SetActive(true);
                break;
            case "Snail":
                SplashUi[2].SetActive(true);
                break;
            case "Walrus": 
                SplashUi[3].SetActive(true);
                break;
            case "Whale": 
                SplashUi[4].SetActive(true);
                break;
            case "Eel":
                SplashUi[5].SetActive(true);
                break;
            case "Shark":
                SplashUi[6].SetActive(true);
                break;
            case "Turtle": 
                SplashUi[7].SetActive(true);
                break;
            case "Monkfish": 
                SplashUi[8].SetActive(true);
                break;
            case "Crayfish": 
                SplashUi[9].SetActive(true);
                break;
            default: break;
        }
       
    }

    void InNode(DNAnode NowNode)
    {
        Nodes[Cur_Node_Num] = NowNode;
        Cur_Node_Num++;
    }

    string Node_Check()
    {
        if (Cur_Node_Num == 3)
        {
            Sums[] NodeValue_Sum = new Sums[10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NodeValue_Sum[i].NodeValue = Nodes[j].NodeValue[i];
                }
            }
            return NodeValue_Sum.Max().Name;
        }
        return "";
    }
}
