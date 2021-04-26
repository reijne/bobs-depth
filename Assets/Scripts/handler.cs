using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handler : MonoBehaviour
{
  public static handler instance;
  public static int depth = 0;
  public static int maxDepth = 1;
  
  void Start() {
    if (instance != null) {
      Destroy(this);
      return;
    }
    instance = this;
    DontDestroyOnLoad(instance);
  }

  public static int healthCalc(int init) {
    return (int) (init + 0.5f*init*depth);
  }

  public static void loadLevel(bool next) {
    if (next) depth += 1;
    else depth -= 1;

    if (depth < 0) depth = 0;
    else if (depth > maxDepth) {
      SceneManager.LoadScene("win");
      return;
    } 
    Debug.Log(string.Format("New depth = {0}", depth));
    SceneManager.LoadScene("template");
  }

  // Update is called once per frame
  void Update()
  {
    
  }
}
