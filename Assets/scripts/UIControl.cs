using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public static UIControl Instance;

    public bool isUpOne;
    public bool isDownOne;

    public bool isUpTwo;
    public bool isDownTwo;

    public bool isDraggingBottom;
    public bool isDraggingUpper;

    public Touch touch1;
    public Touch touch2;

    private void Awake()
    {
        Instance = this;
    }
}
