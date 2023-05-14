using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaFrutas : MonoBehaviour
{
    public Text levelCleared;

    public GameObject trancision;

    public Text total;

    public Text fruitCollecter;

    public int totalfrutasnivel;

    private void Start()
    {
        totalfrutasnivel = transform.childCount;
    }

    private void Update()
    {
        Allfruitcolecter();
        total.text = totalfrutasnivel.ToString();
        fruitCollecter.text = transform.childCount.ToString(); 
    }

   public void Allfruitcolecter(){

    if(transform.childCount==0)
    {
        Debug.Log("No quedan frutas, victoriii");
        levelCleared.gameObject.SetActive(true);
        trancision.SetActive(true);
        Invoke("ChangeScena", 1);
    }
   }

   void ChangeScena(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
}
