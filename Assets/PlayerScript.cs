using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public WallScript wallScript;
    public float speed = 1.0f;
    public float moveTickLimit;
    private float moveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveTickLimit = 1500 * Time.deltaTime;
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
            if (wallScript.hasWall(transform.position.x, transform.position.y+1))
            {
                Debug.Log("Wall detected at: " + transform.position.x + ", " + (transform.position.y + 1.5f)); return; }
            transform.Translate(Vector2.up * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x-1, transform.position.y))
            {
                Debug.Log("Wall detected at: " + (transform.position.x-1) + ", " + (transform.position.y + 0.5f)); return; }
            transform.Translate(new Vector2((int)(-speed), 0));
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x, transform.position.y-1)) {
                Debug.Log("Wall detected at: " + transform.position.x + ", " + (transform.position.y - 0.5f)); return; }
            transform.Translate(Vector2.down * speed);
            moveTimer = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log(transform.position.x + ", " + transform.position.y);
            if (wallScript.hasWall(transform.position.x+1, transform.position.y))
            {
                Debug.Log("Wall detected at: " + (transform.position.x+1) + ", " + (transform.position.y + 0.5f)); return; }
            transform.Translate(new Vector2((int)(speed), 0));
            moveTimer = 0;
        }
    }
}
