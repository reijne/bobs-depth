using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobShoot : MonoBehaviour
{
  public Camera cam;
  public LineRenderer laser;
  public Transform redFirePoint;
  public Transform blueFirePoint;
  public Transform purpleFirePoint;
  public Vector3 offset;

  void Update()
  {
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
      shoot(purpleFirePoint, new Color(.5f, 0, 1));
    } else if (Input.GetMouseButton(0)) {
      shoot(redFirePoint, Color.red);
      Debug.Log("LMB");
    } else if (Input.GetMouseButton(1)) {
      shoot(blueFirePoint, Color.blue);
      Debug.Log("RMB");
    } else {
      laser.enabled = false;
    }  
  }

  void shoot(Transform firepoint, Color color) {
    laser.enabled = true;
    laser.SetPosition(0, firepoint.position + offset);
    laser.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition) + offset);
    laser.startColor = color;
    laser.endColor = color;
  }
}
