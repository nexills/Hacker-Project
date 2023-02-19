using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public WallScript wallScript;
    public HintScript hintScript;
    public GameObject cover;
    public GameManager gameManager;

    public float speed = 1.0f;
    public float moveMsLimit;
    private float moveTimer = 0;

    private bool goalReached = false;

    // Start is called before the first frame update
    void Start()
    {
        moveMsLimit = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (wallScript == null || goalReached) return;
        if (moveTimer < moveMsLimit)
        {
            moveTimer += Time.deltaTime;
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
        if (wallScript.HasWall(transform.position, direction)) return;
        if (wallScript.IsGoal(transform.position, direction))
        {
            gameManager.endGame();
            goalReached = true;
        }
        else
        {
            string hint = wallScript.GetHint(transform.position, direction);
            if (hint != null) hintScript.setText(hint);
        }
        transform.Translate(direction * speed);
        cover.transform.Translate(direction * speed);
        moveTimer = 0;
    }
}
