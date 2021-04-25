using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarLogic : MonoBehaviour
{
  private GameObject bob;
  private spawnMobs spawner;
  public GameObject hand1;
  public GameObject hand2;
  public GameObject obstacle;

  // Health bar stuffs
  public GameObject healthbar;
  public Vector3 initialScale;
  public int healthInit;
  private int health;

  // Ability cooldowns
  public int spawnCooldownInit;
  public int spawnCooldown = 0;
  // Start is called before the first frame update
  void Start() {
    bob = GameObject.Find("bob");
    spawner = GameObject.Find("mobSpawner").GetComponent<spawnMobs>();
    health = handler.healthCalc(healthInit);
    initialScale = healthbar.transform.localScale;
    if (transform.position.x < 0) GetComponent<SpriteRenderer>().flipX = true;
  }

  // Update is called once per frame
  void Update()
  {
    if (spawnCooldown > 0) spawnCooldown--;
    else spawnObstacle();
    Color old = hand1.GetComponent<SpriteRenderer>().color;
    Color changed = new Color(old.r, old.g, old.b, (float)(spawnCooldownInit-spawnCooldown) / spawnCooldownInit);
    hand1.GetComponent<SpriteRenderer>().color =  changed;  
    hand2.GetComponent<SpriteRenderer>().color =  changed;  
  }

  private void OnMouseOver() {
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
      reduceCooldown();
    } else if (Input.GetMouseButton(0)) {
      changeHealthPillar(true);
    } else if (Input.GetMouseButton(1)) {
      changeHealthPillar(false);
    }
  }

  private void reduceCooldown() {
    if (spawnCooldown > 0) spawnCooldown--;
  }

  private void spawnObstacle() {
    Vector3 offset = new Vector3(Random.Range(-2*obstacle.transform.localScale.x, 2*obstacle.transform.localScale.x),
                              Random.Range(-2*obstacle.transform.localScale.y, -2*obstacle.transform.localScale.y),
                              0);
    GameObject.Instantiate(obstacle, bob.transform.position+offset, Quaternion.identity);
    spawnCooldown = spawnCooldownInit;
  }

  private void changeHealthPillar(bool hurt) {
    if (hurt) health--;
    else health ++;

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
}
