using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceLogic : MonoBehaviour
{
  Camera cam;
  private void Start() {
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();
  }
  private void OnCollisionEnter2D(Collision2D other) {
    Debug.Log("hit some ice");
    if (other.collider.tag == "bob") {
      handler.loadLevel(false);
    }
  }

  private void OnMouseOver() {
    if (Input.GetMouseButton(0)) {
      Destroy(this.gameObject);
      Destroy(this);
    }
  }

  private void Update() {
    if (transform.position.x > 2*cam.orthographicSize || transform.position.y > 2*cam.orthographicSize) {
      Destroy(this.gameObject);
      Destroy(this);
    }
  }
}
