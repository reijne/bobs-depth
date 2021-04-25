using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelTracker : MonoBehaviour
{
  public Text level;
  private void FixedUpdate() {
    level.text = handler.depth + "/" + handler.maxDepth;
  }
}
