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
        CreateEdgeArray();

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
        // Create nodes
        for (int i = 1; i <= number; i++)
        {
            graph.CreateNode(i);
        }

        // Buffer node
        graph.CreateNode(-1);
    }

    private void CreateEdgeArray()
    {
        // First choice
        graph.CreateEdge(1, 2);
        graph.CreateEdge(1, 11);


    }
}
