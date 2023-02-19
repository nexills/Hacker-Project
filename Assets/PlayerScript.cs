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
            if (wallScript.hasWall(transform.position, Vector2.up)) return;
            if (wallScript.hasHint(transform.position, Vector2.up)) { hintScript.setText("Hint at x:" + (transform.position.x) + " y:" + (transform.position.y + 1)); }
            transform.Translate(Vector2.up * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (wallScript.hasWall(transform.position, Vector2.left)) return;
            if (wallScript.hasHint(transform.position, Vector2.left)) { hintScript.setText("Hint at x:" + (transform.position.x - 1) + " y:" + (transform.position.y)); }
            transform.Translate(Vector2.left * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (wallScript.hasWall(transform.position, Vector2.down)) return;
            if (wallScript.hasHint(transform.position, Vector2.down)) { hintScript.setText("Hint at x:" + (transform.position.x) + " y:" + (transform.position.y - 1)); }
            transform.Translate(Vector2.down * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (wallScript.hasWall(transform.position, Vector2.right)) return;
            if (wallScript.hasHint(transform.position, Vector2.right)) { hintScript.setText("Hint at x:" + (transform.position.x + 1) + " y:" + (transform.position.y)); }
            transform.Translate(Vector2.right * speed);
            moveTimer = 0;
        }
    }
}
