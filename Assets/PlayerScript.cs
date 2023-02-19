using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public WallScript wallScript;
    public HintScript hintScript;
    public GameObject cover;

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            HandleMove(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            HandleMove(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            HandleMove(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            HandleMove(Vector2.right);
        }
    }

    void HandleMove(Vector2 direction)
    {
        if (wallScript.hasWall(transform.position, direction)) return;
        string hint = wallScript.getHint(transform.position, direction);
        if (hint != null) hintScript.setText(hint);
        transform.Translate(direction * speed);
        cover.transform.Translate(direction * speed);
        moveTimer = 0;
    }
}
