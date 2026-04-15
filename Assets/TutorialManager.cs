using UnityEngine;
using Unityengine.UI;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        public string message;
        public Transform highlightTarget;
    }

    public TutorialStep[] steps;

    public int step = 0;

    public HighlightCircle highlight;
    public TutorialUI ui;

    public Transform fruitTile;
    public Transform lionTile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
