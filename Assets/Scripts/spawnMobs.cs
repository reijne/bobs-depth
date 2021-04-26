using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMobs : MonoBehaviour
{
  public Camera cam;
  public List<GameObject> mobs = new List<GameObject>();
  public GameObject pric;
  public GameObject pillar;
  public GameObject pice;
  public List<Vector3> availCorners = new List<Vector3>();
  
  // Start is called before the first frame update
  void Awake() {
    float xoff = pillar.GetComponent<BoxCollider2D>().size.x;
    float yoff = pillar.GetComponent<BoxCollider2D>().size.y;
    availCorners.Add(new Vector3(cam.orthographicSize*cam.aspect-xoff, cam.orthographicSize-yoff, 0));
    availCorners.Add(new Vector3(-cam.orthographicSize*cam.aspect+xoff, -cam.orthographicSize+yoff, 0));
    availCorners.Add(new Vector3(-cam.orthographicSize*cam.aspect+xoff, cam.orthographicSize-yoff, 0));
    availCorners.Add(new Vector3(cam.orthographicSize*cam.aspect-xoff, -cam.orthographicSize+yoff, 0));
    
    for (int i = 0; i < 1+handler.depth; i++) {
      spawnRandom();
    }

  }

  // Update is called once per frame
  void Update()
  {
      
  }

  private void spawnRandom() {
    int choice = Random.Range(0, 3);
    if (choice == 0 && availCorners.Count > 0) spawnPillar();
    else if (choice == 1) spawnPric(randomLocation());
    else spawnPice(randomLocation());
  }

  private Transform randomLocation() {
    Transform rand = new GameObject().transform;
    rand.position = new Vector3(Random.Range(-cam.orthographicSize*cam.aspect, cam.orthographicSize*cam.aspect),
                                Random.Range(-cam.orthographicSize, cam.orthographicSize),
                                0);
    return rand;
  }

  public void spawnPric(Transform tran) {
    GameObject newPric = GameObject.Instantiate(pric);
    Vector3 offset = new Vector3(Random.Range(-newPric.transform.localScale.x, newPric.transform.localScale.x),
                                 Random.Range(-newPric.transform.localScale.y, newPric.transform.localScale.y),
                                 Random.Range(-newPric.transform.localScale.z, newPric.transform.localScale.z));
    newPric.transform.position = tran.position + offset;
    newPric.transform.localScale = tran.localScale;
    newPric.GetComponent<PricLogic>().dupCooldown = newPric.GetComponent<PricLogic>().dupCooldownInit; 
    mobs.Add(newPric);
  }

  public void spawnPillar() {
    Vector3 pos = availCorners[Random.Range(0, availCorners.Count)];
    availCorners.Remove(pos);
    GameObject newPillar = GameObject.Instantiate(pillar, pos, Quaternion.identity);
    mobs.Add(newPillar);
  }

  public void spawnPice(Transform tran) {
    GameObject newPice = GameObject.Instantiate(pice, tran.position, Quaternion.identity);
    mobs.Add(newPice);
  }
}
