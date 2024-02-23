using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Research : MonoBehaviour
{
    DNAnode[] Nodes;
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
            case "Apple":break;
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
