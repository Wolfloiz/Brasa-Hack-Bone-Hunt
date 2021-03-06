using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    // Start is called before the first frame update
    void Start() {
        dest = transform.position;
    }

    // Update is called once per frame
    // FixedUpdate is called in a fixed time interval
    void FixedUpdate() {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        Debug.Log("dest = " + dest.ToString() + " | transform.position = " + transform.position.ToString());
        if (almostEqual((Vector2)transform.position, dest)) {
            Debug.Log("If");
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir) {
        Vector2 pos = transform.position;
        Debug.Log("pos + dir = " + (pos + dir));        
        RaycastHit2D hit = Physics2D.Linecast(pos + 1.2f * dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    bool almostEqual(Vector2 u, Vector2 v) {
        return ((u - v).sqrMagnitude < Mathf.Pow(10, -4));
    }
}
