using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private StandardGraph graph;
    public Text display;

    private void Start()
    {
        graph = new StandardGraph();

        graph.CreateNode(1);
        graph.CreateNode(2);
        graph.CreateNode(3);
        graph.CreateNode(4);
        graph.CreateNode(5);
        graph.CreateNode(6);
        graph.CreateNode(7);
        graph.CreateNode(8);

        graph.CreateEdge(1, 3);
        graph.CreateEdge(3, 6);
        graph.CreateEdge(2, 4);
        graph.CreateEdge(4, 6);
        graph.CreateEdge(2, 5);
        graph.CreateEdge(5, 7);
        graph.CreateEdge(7, 8);

        display.text = graph.ToString();
    }
}
