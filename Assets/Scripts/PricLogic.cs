using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PricLogic : MonoBehaviour
{
  private spawnMobs spawner;
  private GameObject bob;
  public float moveSpeed;

  // Health bar stuffs
  public GameObject healthbar;
  public Vector3 initialScale;
  public int healthInit;
  private int health;

  // Ability cooldowns
  public int dupCooldownInit;
  public int dupCooldown = 0;
  public int shrinkCooldownInit;
  public int shrinkCooldown = 0;

  private void Start() {
    bob = GameObject.Find("bob");
    spawner = GameObject.Find("mobSpawner").GetComponent<spawnMobs>();
    health = handler.healthCalc(healthInit);
    initialScale = healthbar.transform.localScale;
    Debug.Log(initialScale);
  }

  // Update is called once per frame
  void Update() {
    Vector3 dir = (bob.transform.position - transform.position).normalized;
    transform.position += dir * moveSpeed * Time.deltaTime;
  }

  private void OnMouseOver() {
    if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
      hurtPric();
    } else if (Input.GetMouseButton(0)) {
      duplicatePric();
    } else if (Input.GetMouseButton(1)) {
      shrinkPric();
    }
  }

  private void FixedUpdate() {
    if (dupCooldown > 0) dupCooldown--;
    if (shrinkCooldown > 0) shrinkCooldown--;
  }

  private void duplicatePric() {
    if (dupCooldown == 0) {
      spawner.spawnPric(transform);
      dupCooldown = dupCooldownInit;
    }
  }

  private void hurtPric() {
    health--;
    healthbar.SetActive(true);
    healthbar.transform.localScale = new Vector3(initialScale.x * ((float)health / (healthInit +  healthInit * handler.depth)),
                                                 initialScale.y,
                                                 initialScale.z);
    if (health <= 0) {
      spawner.mobs.Remove(this.gameObject);
      Destroy(this.gameObject);
      Destroy(this);
    }
  }

  private void shrinkPric() {
    if (shrinkCooldown == 0) {
      transform.localScale *= 0.8f; 
      moveSpeed *= 1.2f;
      shrinkCooldown = shrinkCooldownInit;
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    handler.loadLevel(false);
  }
}
