using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private StandardGraph graph;
    public Text display;

    //void Start()
    //{
    //    graph = new Graph(8);
    //    graph.CreateEdge(0, 2);
    //    graph.CreateEdge(1, 3);
    //    graph.CreateEdge(1, 4);
    //    graph.CreateEdge(2, 5);
    //    graph.CreateEdge(3, 5);
    //    graph.CreateEdge(4, 6);
    //    graph.CreateEdge(6, 7);

    //    graph.CreateMatrix(graph, display);
    //}

    private void Start()
    {
        graph = new StandardGraph();
    }
}
