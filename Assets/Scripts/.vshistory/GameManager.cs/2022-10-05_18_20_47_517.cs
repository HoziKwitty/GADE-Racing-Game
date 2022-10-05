using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text results;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        results.text = "";
    }
}
