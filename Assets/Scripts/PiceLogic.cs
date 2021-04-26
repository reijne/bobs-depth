using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiceLogic : MonoBehaviour
{
  private GameObject bob;
  private spawnMobs spawner;
  public GameObject ice;

  // Health bar stuffs
  public GameObject healthbar;
  public Vector3 initialScale;
  public int healthInit;
  private int health;
  public float shootSpeed;
  private bool frozen;
  // Start is called before the first frame update
  void Start() {
    bob = GameObject.Find("bob");
    spawner = GameObject.Find("mobSpawner").GetComponent<spawnMobs>();
    health = handler.healthCalc(healthInit);
    initialScale = healthbar.transform.localScale;
  }

  // Update is called once per frame
  void Update() {
    if (frozen) {
      bob.GetComponent<BobMove>().moveSpeed = 0;
    } else {
      bob.GetComponent<BobMove>().moveSpeed = bob.GetComponent<BobMove>().moveSpeedInit;
    }
    frozen = false;
  }

  private void OnMouseOver() {
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
      shootIce();
    } else if (Input.GetMouseButton(0)) {
      frozen = true;
    } else if (Input.GetMouseButton(1)) {
      hurtPice();
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

  private void updateHealthbar() {
    healthbar.SetActive(true);
    healthbar.transform.localScale = new Vector3(initialScale.x * ((float)health / (healthInit +  healthInit * handler.depth)),
                                                 initialScale.y,
                                                 initialScale.z);
  }

  private void shootIce() {
    GameObject iceshot = GameObject.Instantiate(ice, transform.position, Quaternion.identity);
    Vector2 dir = new Vector2(bob.transform.position.x - transform.position.x,
                              bob.transform.position.y - transform.position.y);
    Debug.Log(dir);
    Debug.Log(shootSpeed*dir);
    iceshot.GetComponent<Rigidbody2D>().velocity = shootSpeed * dir;
  }
}
