using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

    private PaddleController paddle;
    public bool HasStarted = false;
    private Vector3 PaddletoBallVector ;
    public float Ballspeed;
    private Vector2 paddlePosition, ballposition;
    private Vector2 loop = new Vector2(0f, 1f);
    // Use this for initialization
    void Start()
    {
        
        paddle = GameObject.FindObjectOfType<PaddleController>();
        PaddletoBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasStarted) {
            this.transform.position = paddle.transform.position + PaddletoBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                HasStarted = true;
                Vector3 curve = new Vector3(5f, 0f);
                this.GetComponent<Rigidbody2D>().velocity = PaddletoBallVector.normalized * Ballspeed + curve;
            }
        }
        if (HasStarted)
        {

            if (this.GetComponent<Rigidbody2D>().velocity.y == 0f) this.GetComponent<Rigidbody2D>().velocity += loop;
        }

       
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        
        if (HasStarted)
        {
            if (collision2D.gameObject.name == "Paddle")
            {
                Vector2 direction = BounceDirection(collision2D);
                
                this.GetComponent<Rigidbody2D>().velocity = direction * Ballspeed;
                
            }
            gameObject.GetComponent<AudioSource>().Play();
            
        }
    }

    Vector2 BounceDirection(Collision2D hitObject)
    {
        Vector2 collidingPosition = hitObject.transform.position;
        ballposition = this.transform.position;
        Vector2 delta = ballposition - collidingPosition;
        
        return (delta.normalized);

    }
}
