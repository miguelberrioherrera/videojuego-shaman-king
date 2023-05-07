using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MascaraRespaun : MonoBehaviour
{
    private float checkPointPositionx, checkPointPositiony;

    public Animator animator;

    void Start()
    {
        if(PlayerPrefs.GetFloat("checkPointPositionx")!=0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionx"), PlayerPrefs.GetFloat("checkPointPositiony")));
        }     
    }

    public void ReachedCheckPoint(float x, float y)
    {

        PlayerPrefs.SetFloat("checkPointPositionx", x);
        PlayerPrefs.SetFloat("checkPointPositiony", y);
    }

    public void PlayerDamaged()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
