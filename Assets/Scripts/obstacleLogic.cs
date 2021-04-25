using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleLogic : MonoBehaviour
{
  public int liveSpanInit;
  public int liveSpan;
  // Start is called before the first frame update
  void Start()
  {
    liveSpan = liveSpanInit + liveSpanInit * handler.depth;
  }

  // Update is called once per frame
  void Update()
  {
    Color old = GetComponent<SpriteRenderer>().color;
    GetComponent<SpriteRenderer>().color = new Color(old.r, old.g, old.b, (float)liveSpan/(liveSpanInit + liveSpanInit * handler.depth));
    liveSpan--;
    if (liveSpan <= 0) {
      Destroy(this.gameObject);
      Destroy(this);
    }
  }
}
