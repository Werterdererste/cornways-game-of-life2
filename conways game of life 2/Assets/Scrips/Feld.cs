using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feld : MonoBehaviour
{
    public int maxX = 10;
    public int maxY = 10;
    public GameObject zelle;
    public GameObject[,] zellen;

    public bool play = false;
    public int geschwindigkeit = 1;

    bool next = true;
    int gen = 0;
    int[] nachbarX = new int[] {1, 1, 0, -1, -1, -1, 0,1 };
    int[] nachbarY = new int[] {0, -1, -1, -1, 0, 1, 1, 1 };
    void Start()
    {        
        zellen = new GameObject[maxX, maxY];
        Generator();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            play = true;
            //NextGeneration();
        }

        if (play&&next)
        {
            
            next = false;
            StartCoroutine(Gamehandel());
        }
    }

    IEnumerator Gamehandel()
    {
        NextGeneration();
        yield return new WaitForSeconds(0.5f/geschwindigkeit);
        next = true;
        gen++;
        print(gen);
    }
    public void NextGeneration()
    {            
        NextGeneretionCheck();

        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                zellen[x, y].GetComponent<Zellle>().SetLife();
            }
        }
    }

    void NextGeneretionCheck()
    {
        for(int x = 0; x < maxX; x++)
        {
            for(int y = 0; y < maxY; y++)
            {
                //zelle Lebt
                if (zellen[x, y].GetComponent<Zellle>().GetLife())
                {
                    if (Nachbarcheck(x, y) <2)
                    {
                        zellen[x, y].GetComponent<Zellle>().SetNextLife(false);
                    }
                    else if (Nachbarcheck(x, y) > 3)
                    {
                        zellen[x,y].GetComponent<Zellle>().SetNextLife(false);
                    }
                    else
                    {
                        zellen[x, y].GetComponent<Zellle>().SetNextLife(true);

                    }
                }
                //zelle Tot
                else
                {
                    if(Nachbarcheck(x,y) == 3)
                    {
                        zellen[x,y].GetComponent<Zellle>().SetNextLife(true); 
                    }
                }
            }
        }
    }

    int Nachbarcheck(int x,int y)
    {
        //lebende Nachbarn werden gezählt
        int nachbarn = 0;            
        //print("zelle " + x + " " + y);
        for(int i = 0; i < nachbarX.Length; i++)
        {
            //print("nachbar " + i + " pos "+ nachbarX[i] +" " + nachbarY[i]);
           // print("real " + (nachbarX[i] + x) + " " + (nachbarY[i] + y));
            try{
                if (zellen[nachbarX[i] + x, nachbarY[i] + y].GetComponent<Zellle>().GetLife())
                {
                    nachbarn++;
                }
            }
            catch{}
        }
        return nachbarn;
    }
    void Generator()
    {
        for(int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                Vector2 vector2 = new Vector2(x - (maxX / 2), y - (maxY / 2));
                GameObject go = Instantiate(zelle, vector2, Quaternion.identity);
                zellen[x, y] = go;

                zellen[x,y].GetComponent<Zellle>().x = x;
                zellen[x,y].GetComponent<Zellle>().y = y;
            }               
        }
    }
    public void SetPlay(bool status)
    {
        play = status;
    }
    public bool GetPlay()
    {
        return play;
    }   
    public void Setgeschwindigkeit(int speed)
    {
        geschwindigkeit = speed;
    }
    public int GetGeneration()
    {
        return gen;
    }
}
