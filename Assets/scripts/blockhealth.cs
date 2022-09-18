using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockhealth : MonoBehaviour
{
    int hp;
    public Sprite[] squareCracked;
    Color color;
    Color color0 = new Color(1, 0, 0, 1);
    Color color1 = new Color(0, 1, 0, 1);
    Color color2 = new Color(1, 1, 0, 1);
    Color color3 = new Color(1, 0, 1, 1);
    Color color4 = new Color(0,1,1,1);

    private void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        if (color.Equals(color0))
        {
            hp = 4;
        }
        else if (color.Equals(color1))
        {
            hp = 3;
        }
        else if (color.Equals(color2))
        {
            hp = 2;
        }
        else if (color.Equals(color3))
        {
            hp = 1;
        }
        else
        {
            hp = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp > 0)
        {
            GetComponent<SpriteRenderer>().sprite = squareCracked[hp-1];
            hp--;
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
