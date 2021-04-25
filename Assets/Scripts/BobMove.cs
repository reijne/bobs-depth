using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMove : MonoBehaviour
{
  public Camera cam;
  public Transform redFirePoint;
  public Transform blueFirePoint;
  private bool flipped = false;
  public float moveSpeedInit;
  public float moveSpeed;
  public float vertLimit;
  public float horLimit;

  private void Start() {
    moveSpeed = moveSpeedInit;
  }

  /// <summary>Handle the movement for a the bob character</summary>
  void Update() {
    float vert = Input.GetAxis("Vertical");
    float hor = Input.GetAxis("Horizontal");

    // Clip to the screen edges
    // if (Mathf.Abs(transform.position.y + vert * moveSpeed * Time.deltaTime) >= vertLimit*cam.orthographicSize) {
    //   vert = 0;
    // }
    // if (Mathf.Abs(transform.position.x + hor * moveSpeed * Time.deltaTime) >= horLimit*cam.orthographicSize * cam.aspect) {
    //   hor = 0;
    // }

    flipper(vert, hor);
    Vector3 direction = new Vector3(hor, vert, 0f);
    transform.position += direction * moveSpeed * Time.deltaTime;
  }

  /// <summary>flip bob if we moving da otha way</summary>
  void flipper (float vert, float hor) {
    if (hor < 0) {
      GetComponent<SpriteRenderer>().flipX = true;
    } else if (hor > 0) {
      GetComponent<SpriteRenderer>().flipX = false;
    }
    if (flipped != GetComponent<SpriteRenderer>().flipX) flipPoints();
  }

  /// <summary>flip fire points since bob is flippered</summary>
  void flipPoints() {
    Vector3 temp = redFirePoint.position;
    redFirePoint.position = blueFirePoint.position;
    blueFirePoint.position = temp;
    flipped = !flipped;
  }
}
