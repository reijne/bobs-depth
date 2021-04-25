using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingGoto : MonoBehaviour
{
  public spawnMobs spawner;
  public bool next;
  private void OnCollisionEnter2D(Collision2D other) {
    if (spawner.mobs.Count == 0 && next) {
      if (other.collider.tag == "bob") handler.loadLevel(next);
    } else if (spawner.mobs.Count != 0 && !next) {
      if (other.collider.tag == "bob") handler.loadLevel(next);
    }
  }
}
