using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiceLogic : MonoBehaviour
{
  private GameObject bob;
  private spawnMobs spawner;
  // Health bar stuffs
  public GameObject healthbar;
  public Vector3 initialScale;
  public int healthInit;
  private int health;
  // Start is called before the first frame update
  void Start() {
    bob = GameObject.Find("bob");
    spawner = GameObject.Find("mobSpawner").GetComponent<spawnMobs>();
    health = handler.healthCalc(healthInit);
    initialScale = healthbar.transform.localScale;
  }

  // Update is called once per frame
  void Update() {
      
  }

  private void OnMouseOver() {
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
      
    } else if (Input.GetMouseButton(0)) {
      freezeBob();
    } else if (Input.GetMouseButton(1)) {
      hurtPice();
    } else {
      bob.GetComponent<BobMove>().moveSpeed = bob.GetComponent<BobMove>().moveSpeedInit; 
    }
  }

  private void hurtPice() {
    health--;
    updateHealthbar();
    if (health <= 0) {
      spawner.mobs.Remove(this.gameObject);
      Destroy(this.gameObject);
      Destroy(this);
    }
  }

  private void freezeBob() {
    bob.GetComponent<BobMove>().moveSpeed = 0;
  }

  private void updateHealthbar() {
    healthbar.SetActive(true);
    healthbar.transform.localScale = new Vector3(initialScale.x * ((float)health / (healthInit +  healthInit * handler.depth)),
                                                 initialScale.y,
                                                 initialScale.z);
  }
}
