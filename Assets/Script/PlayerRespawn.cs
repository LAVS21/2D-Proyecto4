using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerPrefs.GetInt("checkPointScene") == SceneManager.GetActiveScene().buildIndex)
        {
            if (PlayerPrefs.GetFloat("checkPointX") != 0 && PlayerPrefs.GetFloat("checkPointY") != 0)
            {
                transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointX"),
                    PlayerPrefs.GetFloat("checkPointY"));
            }
        }
    }

    public void ReachedCheckPoint(float x, float y, int scene)
    {
        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointY", y);
        PlayerPrefs.SetInt("checkPointScene", scene);
    }

    public void PlayerDamaged()
    {
        animator.Play("Hit");
        Invoke("NextScene", 1);
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}