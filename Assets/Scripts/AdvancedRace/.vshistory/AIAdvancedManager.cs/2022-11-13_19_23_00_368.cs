using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIAdvancedManager : MonoBehaviour
{
    // Singleton
    public static AIAdvancedManager instance;

    // UI References
    public Image resultsImage;
    private Text resultsText;

    public Image positionImage;
    public Text position;
    public List<Sprite> positionSprites;

    public Text lapText;

    // Object references
    public GameObject player;
}
