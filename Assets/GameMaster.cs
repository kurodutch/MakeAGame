using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static int CurrentScore = 0;
    public float OffsetY = 40;
    public float SizeX = 100;
    public float SizeY = 40;


    // Update is called once per frame
    void Update () {
        
	}
    private void Start()
    {
        CurrentScore = 0;
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - SizeX / 2, OffsetY, SizeX, SizeY), "Score: " + CurrentScore);
        
    }
}
