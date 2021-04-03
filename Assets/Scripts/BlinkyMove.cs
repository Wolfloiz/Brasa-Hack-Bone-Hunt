using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyMove : MonoBehaviour {
    public Transform[] waypoints;
    public float speed = 0.3f;
    int cur = 0;
    
    void FixedUpdate () {
        if (!almostEqual(transform.position, waypoints[cur].position)) {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void FixedUpdateBackup () {
        if (!almostEqual(transform.position, waypoints[cur].position)) {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "Pacman")
            Destroy(co.gameObject);
    }

    bool almostEqual(Vector3 u, Vector3 v) {
        return ((u - v).sqrMagnitude < Mathf.Pow(10, -4));
    }
}
