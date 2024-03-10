using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Research : MonoBehaviour
{
    class DNAnode
    {
        public int Ray;
        public int Starfish;
        public int snail;
        public int Walrus;
        public int Whale;
        public int Eel;
        public int Shark;
        public int Turtle;
        public int Monkfish;
        public int Crayfish;
    }
    GameObject[] ResearchUi;
    DNAnode[] Nodes;
    GameObject[] SplashUi;
    int Cur_Node_Num = 0;
    [SerializeField] Room[] rooms;
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
        NodeSum();
    }

    void InNode(DNAnode NowNode)
    {
        Nodes[Cur_Node_Num] = NowNode;
        Cur_Node_Num++;
    }

    int NodeSum()
    {
        if (Cur_Node_Num == 3)
        {
            int[] SumValue = new int[10];
            for (int i = 0; i < 3; i++)
            {
                SumValue[0] += Nodes[i].Ray;
                SumValue[1] += Nodes[i].Starfish;
                SumValue[2] += Nodes[i].snail;
                SumValue[3] += Nodes[i].Walrus;
                SumValue[4] += Nodes[i].Whale;
                SumValue[5] += Nodes[i].Eel;
                SumValue[6] += Nodes[i].Shark;
                SumValue[7] += Nodes[i].Turtle;
                SumValue[8] += Nodes[i].Monkfish;
                SumValue[9] += Nodes[i].Crayfish;
            }
            int max = SumValue[0];
            int count = 1;
            for (int i = 1; i < 10; i++)
            {
                if (max < SumValue[i])
                    count++;
            }
            rooms[GameManager.Gameinstance.Room_Num].CareSplash = true;
            rooms[GameManager.Gameinstance.Room_Num].Splashes[count].SetActive(true);
        }
        return 0;
    }


}
