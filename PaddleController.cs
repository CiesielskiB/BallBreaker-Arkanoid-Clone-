using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public bool autoplay;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	// Update is called once per frame
	void Update () {
        if (!autoplay)
        {
            MovementwithMouse();
        }
        else
        {
            Autoplay();
        }
        
	}

    void MovementwithMouse()
    {
        Vector3 paddlepos = new Vector3(0f, this.transform.position.y, this.transform.position.z);

        float mouseposition = Input.mousePosition.x / Screen.width * 16;

        paddlepos.x = Mathf.Clamp(mouseposition, 1.16f, 14.84f);

        this.transform.position = paddlepos;
    }

    void Autoplay()
    {
        Vector3 paddlepos = new Vector3(0f, this.transform.position.y, this.transform.position.z);
        Vector2 ballPos = ball.transform.position;

        paddlepos.x = Mathf.Clamp(ballPos.x, 1.16f, 14.84f);

        this.transform.position = paddlepos;
    }
}
