using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starter : MonoBehaviour
{
  public void startGame() {
    SceneManager.LoadScene("template");
  }
}
