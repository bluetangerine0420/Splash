using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Research : MonoBehaviour
{
    DNAnode[] Nodes;
    int Cur_Node_Num = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void InNode(DNAnode NowNode)
    {
        Nodes[Cur_Node_Num] = NowNode;
        Cur_Node_Num++;
    }

    int Node_Check()
    {
        int[] NodeValue_Sum = new int[10];
        if (Cur_Node_Num == 3)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NodeValue_Sum[i] = Nodes[j].NodeValue[i];
                }
            }
        }

        return 1;
    }
}
