using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Test : MonoBehaviour
{
    private Graph graph;

    void Start()
    {
        graph = new Graph(8);
        graph.CreateEdge(0, 2);
        graph.CreateEdge(1, 3);
        graph.CreateEdge(1, 4);
        graph.CreateEdge(2, 5);
        graph.CreateEdge(3, 5);
        graph.CreateEdge(4, 6);
        graph.CreateEdge(6, 7);

        graph.CreateMatrix(graph);
    }

    void Update()
    {
        
    }
}
