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
            string hint = wallScript.getHint(transform.position, Vector2.up);
            if (hint != null) { hintScript.setText(hint); }
            transform.Translate(Vector2.up * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (wallScript.hasWall(transform.position, Vector2.left)) return;
            string hint = wallScript.getHint(transform.position, Vector2.left);
            if (hint != null) { hintScript.setText(hint); }
            transform.Translate(Vector2.left * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (wallScript.hasWall(transform.position, Vector2.down)) return;
            string hint = wallScript.getHint(transform.position, Vector2.down);
            if (hint != null) { hintScript.setText(hint); }
            transform.Translate(Vector2.down * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (wallScript.hasWall(transform.position, Vector2.right)) return;
            string hint = wallScript.getHint(transform.position, Vector2.right);
            if (hint != null) { hintScript.setText(hint); }
            transform.Translate(Vector2.right * speed);
            moveTimer = 0;
        }
    }
}
