using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Research : MonoBehaviour
{
    [SerializeField] Splash[] Splashes;
    [SerializeField] NodeScript[] Nodes;
    [SerializeField] GameObject[] SplashUi;
    [SerializeField] int Cur_Node_Num = 0;
    [SerializeField] Room[] rooms;
    [SerializeField] GameObject[] NodeCheckPoint;
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
        if (Cur_Node_Num > 0)
            NodeCheckPoint[Cur_Node_Num - 1].SetActive(true);
    }

    public void InNode(NodeScript NowNode)
    {
        if (Cur_Node_Num < 3)
        {
            Nodes[Cur_Node_Num] = NowNode;
            Cur_Node_Num++;
        }
    }

            
    public void NodeSum()
    {
        if (Cur_Node_Num == 3)
        {
            Cur_Node_Num = 0;
            for(int i=0; i<3; i++) NodeCheckPoint[i].SetActive(false);
            int[] SumValue = new int[6];
            for (int i = 0; i < 3; i++)
            {
                SumValue[0] += Nodes[i].Ray;
                SumValue[1] += Nodes[i].Starfish;
                SumValue[2] += Nodes[i].Whale;
                SumValue[3] += Nodes[i].Eel;
                SumValue[4] += Nodes[i].Shark;
                SumValue[5] += Nodes[i].Monkfish;
            }
            int max = Array.FindIndex(SumValue, x => x == SumValue.Max());
            if(GameManager.Gameinstance!=null)
            rooms[GameManager.Gameinstance.Room_Num].CareSplash = Splashes[max];
            else if(GameManager.Gameinstance==null) rooms[0].CareSplash = Splashes[max];
        }
        return;
    }
    public void OFF(GameObject Ui)
    {
        Ui.SetActive(false);
    }

}
