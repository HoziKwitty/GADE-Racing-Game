using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private int length = 50;

    private Graph graph;
    public Text display;

    private void Start()
    {
        graph = new Graph();

        CreateNodeArray(length);

        graph.CreateNode(1);
        graph.CreateNode(-1);

        graph.CreateEdge(1, 3);
        graph.CreateEdge(3, 6);
        graph.CreateEdge(2, 4);
        graph.CreateEdge(4, 6);
        graph.CreateEdge(2, 5);
        graph.CreateEdge(5, 7);
        graph.CreateEdge(7, 8);

        display.text = graph.ToString();
    }

    private void CreateNodeArray(int number)
    {
        for (int i = 0; i < number; i++)
        {

        }
    }
}
