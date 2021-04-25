using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camstuffs : MonoBehaviour
{
  /// <summary>Darken the background color based on the current depth</summary>
  private void Awake() {
    float col = (float)(handler.maxDepth - handler.depth) / handler.maxDepth;
    this.GetComponent<Camera>().backgroundColor = new Color(col, col, col);
  }
}
