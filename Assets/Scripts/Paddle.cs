using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddlePosMax = 16f;
    [SerializeField] float paddlePosMin = 0f;

    //cached references
    GameStatus theGameStatus;
    Ball theBall;

    // Use this for initialization
    void Start ()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), paddlePosMin, paddlePosMax);
        transform.position = paddlePos; 
	}

    private float  GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
