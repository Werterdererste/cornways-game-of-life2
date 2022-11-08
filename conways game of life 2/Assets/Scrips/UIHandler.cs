using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text playtext;
    public Text generation;
    void Start()
    {
        generation.GetComponent<Text>();
    }
    void Update()
    {
        generation.text = GameObject.Find("Feld").GetComponent<Feld>().GetGeneration().ToString();
    }
    public void Play()
   {
        print("ddd");
        
        if (GameObject.Find("Feld").GetComponent<Feld>().GetPlay())
        {
            GameObject.Find("Feld").GetComponent<Feld>().SetPlay(false);
            playtext.text = "Pause";
        }
        else
        {
            GameObject.Find("Feld").GetComponent<Feld>().SetPlay(true);
            playtext.text = "Play";
        }
   }
   public void Speed1x()
   {
        GameObject.Find("Feld").GetComponent<Feld>().Setgeschwindigkeit(1);

   }
   public void Speed2x()
   {
        GameObject.Find("Feld").GetComponent<Feld>().Setgeschwindigkeit(2);

   }
   public void Speed5x()
   {
        GameObject.Find("Feld").GetComponent<Feld>().Setgeschwindigkeit(5);
   }
   public void Speed10x()
   {
        GameObject.Find("Feld").GetComponent<Feld>().Setgeschwindigkeit(100);
   }
}

