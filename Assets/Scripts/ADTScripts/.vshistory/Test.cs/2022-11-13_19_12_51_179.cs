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
        // First fork
        graph.CreateEdge(1, 2);
        graph.CreateEdge(1, 11);

        // Choice 1
        graph.CreateEdge(2, 3);
        graph.CreateEdge(3, 4);
        graph.CreateEdge(4, 5);
        graph.CreateEdge(5, 6);
        graph.CreateEdge(6, 7);
        graph.CreateEdge(7, 8);
        graph.CreateEdge(8, 9);
        graph.CreateEdge(9, 10);

        // Choice 2
        graph.CreateEdge(11, 12);
        graph.CreateEdge(12, 13);
        graph.CreateEdge(13, 14);
        graph.CreateEdge(14, 15);
        graph.CreateEdge(15, 16);
        graph.CreateEdge(16, 17);
        graph.CreateEdge(17, 18);
        graph.CreateEdge(18, 19);

        // First merge
        graph.CreateEdge(20, 21);
        graph.CreateEdge(21, 22);
        graph.CreateEdge(22, 23);
        graph.CreateEdge(23, 24);
        graph.CreateEdge(24, 25);
        graph.CreateEdge(25, 26);
        graph.CreateEdge(26, 27);
        graph.CreateEdge(27, 28);

        // Second fork
        graph.CreateEdge(28, 29);
        graph.CreateEdge(28, 40);

        // Choice 1
        graph.CreateEdge(29, 30);
        graph.CreateEdge(30, 31);
        graph.CreateEdge(31, 32);
        graph.CreateEdge(32, 33);
        graph.CreateEdge(33, 34);
        graph.CreateEdge(34, 35);
        graph.CreateEdge(35, 36);
        graph.CreateEdge(36, 37);
        graph.CreateEdge(37, 38);
        graph.CreateEdge(38, 39);

        // Choice 3
        graph.CreateEdge(29, 30);
    }
}
