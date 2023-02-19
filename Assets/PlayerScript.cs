using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public WallScript wallScript;
    public HintScript hintScript; 

    public float speed = 1.0f;
    public float moveTickLimit;
    private float moveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveTickLimit = 7500 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (wallScript == null) return;
        if (moveTimer < moveTickLimit)
        {
            moveTimer++;
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x, transform.position.y + 1)) return;
            if (wallScript.hasHint(transform.position.x, transform.position.y + 1)) { hintScript.setText("Hint at x:" + (transform.position.x) + " y:" + (transform.position.y + 1)); }
            transform.Translate(Vector2.up * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x - 1, transform.position.y)) return;
            if (wallScript.hasHint(transform.position.x - 1, transform.position.y)) { hintScript.setText("Hint at x:" + (transform.position.x - 1) + " y:" + (transform.position.y)); }
            transform.Translate(new Vector2((int)(-speed), 0));
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x, transform.position.y - 1)) return;
            if (wallScript.hasHint(transform.position.x, transform.position.y - 1)) { hintScript.setText("Hint at x:" + (transform.position.x) + " y:" + (transform.position.y - 1)); }
            transform.Translate(Vector2.down * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x + 1, transform.position.y)) return;
            if (wallScript.hasHint(transform.position.x + 1, transform.position.y)) { hintScript.setText("Hint at x:" + (transform.position.x + 1) + " y:" + (transform.position.y)); }
            transform.Translate(new Vector2((int)(speed), 0));
            moveTimer = 0;
        }
    }
}
