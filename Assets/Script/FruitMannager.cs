using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitMannager : MonoBehaviour
{
    public Text text;
    int Total;
    public Text levelCleared;
    void Start()
    {   
        //Cuenta las frutas en pantalla
        Total = gameObject.transform.childCount;
        FruitCount();
    }

    void Update()
    {
        FruitCount();
    }

    void FruitCount()
    {
        //CUENTA LAS FRUTAS EN PANTALLA
        int count = gameObject.transform.childCount;
        text.text = "Frutas recolectadas: " + (Total - count) + " / " + Total;
        if(count == 0)
        {
            //Muestra el texto
            levelCleared.gameObject.SetActive(true);
            //Cambia de nivel en un tiempo de 2 segundos
            Invoke("ChangeScene", 2);
            
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
