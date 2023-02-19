using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallScript : MonoBehaviour
{
    public GameObject block;
    private int[,] posList = { { -4, -8 }, { -3, -8 }, { -2, -8 }, { 0, -8 }, { -8, -7 }, { -7, -7 }, { -6, -7 },
            { -2, -7 }, { 2, -7 }, { 3, -7 }, { 4, -7 }, { 5, -7 }, { 6, -7 }, { -8, -6 }, { -7, -6 }, { -4, -6 },
            { -2, -6 }, { -1, -6 }, { 1, -6 }, { 2, -6 }, { 6, -6 }, { -7, -5 }, { -5, -5 }, { -4, -5 }, { 1, -5 },
            { 4, -5 }, { 6, -5 }, { -7, -4 }, { -6, -4 }, { -5, -4 }, { -4, -4 }, { -2, -4 }, { -1, -4 },
            { 0, -4 }, { 1, -4 }, { 3, -4 }, { 4, -4 }, { 5, -4 }, { 6, -4 }, { -7, -3 }, { 1, -3 }, { -7, -2 },
            { -5, -2 }, { -4, -2 }, { -3, -2 }, { -1, -2 }, { 1, -2 }, { 2, -2 }, { 3, -2 }, { 4, -2 }, { 5, -2 },
            { 6, -2 }, { -5, -1 }, { -1, -1 }, { 3, -1 }, { 6, -1 }, { -8, 0 }, { -7, 0 }, { -6, 0 }, { -5, 0 },
            { -4, 0 }, { -3, 0 }, { -2, 0 }, { -1, 0 }, { 0, 0 }, { 1, 0 }, { 3, 0 }, { 4, 0 }, { 6, 0 },
            { -5, 1 }, { 0, 1 }, { 1, 1 }, { 4, 1 }, { 6, 1 }, { -7, 2 }, { -5, 2 }, { -3, 2 }, { -2, 2 },
            { 0, 2 }, { 4, 2 }, { 6, 2 }, { 7, 2 }, { -7, 3 }, { -2, 3 }, { 3, 3 }, { 4, 3 }, { -7, 4 },
            { -6, 4 }, { -4, 4 }, { -3, 4 }, { -2, 4 }, { -1, 4 }, { 1, 4 }, { 3, 4 }, { 4, 4 }, { 6, 4 },
            { -7, 5 }, { 1, 5 }, { 6, 5 }, { -7, 6 }, { -6, 6 }, { -5, 6 }, { -4, 6 }, { -2, 6 }, { 0, 6 },
            { 1, 6 }, { 2, 6 }, { 3, 6 }, { 5, 6 }, { 6, 6 }, { -2, 7 }, { 5, 7 }, { 6, 7 } };
    private int[,] hintPos = { { 2, 7 }, { 7, 7 }, { -6, 5 }, { -6, 1 }, { -2, 1 }, { 7, 1 },
    {-4, -1 }, {4, -1 }, {-8, -5 }, {-6, -5 }, {-8,-8 }, {-1,-8 } };
    private string[] hints =
    {
        "Qui n'avance pas, recule.",
        "Ce la fai!",
        "Riprovaci!",
        "Chi si volta, e chi si gira, sempre a casa va finire",
        "Il n’y a pas de raccourci pour aller là où ça vaut la peine d’aller.",
        "千里之行始於足下",
        "欲速則不達",
        "有意栽花花不發，無心插柳柳成陰",
        "執輸行頭，慘過敗家",
        "犬も歩けば棒に当たる",
        "七転び八起き",
        "อย่าล้มเลิก"
    };

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < posList.GetLength(0); i++)
        {
            Instantiate(block, new Vector3(posList[i,0], posList[i,1]+(float)0.5, 1), transform.rotation);
        }
        for (int i = -9; i < 9; i++)
        {
            Instantiate(block, new Vector3(i, 8.5f, 1), transform.rotation);
            Instantiate(block, new Vector3(i, -8.5f, 1), transform.rotation);
        }
        for (int i = -8; i < 8; i++)
        {
            Instantiate(block, new Vector3(8, i + (float)0.5, 1), transform.rotation);
            Instantiate(block, new Vector3(-9, i + (float)0.5, 1), transform.rotation);
        }
    }
            
    public bool hasWall(Vector3 origin, Vector2 direction)
    {
        float x = origin.x + direction.x;
        float y = origin.y + direction.y;
        for (int i = 0; i < posList.GetLength(0); i++)
        {
            if (System.Math.Abs(posList[i, 0] - x) < 0.5f && System.Math.Abs(posList[i, 1] + 0.5f - y) < 0.5f)
            {
                return true;
            }
        }
        if (x < -8.0f || x > 7.0f || y < -7.5f || y > 7.5f)
        {
            return true;
        }
        return false;
    }


    public string getHint(Vector3 origin, Vector2 direction)
    {
        float x = origin.x + direction.x;
        float y = origin.y + direction.y;
        for (int i = 0; i < hintPos.GetLength(0); i++)
        {
            if (System.Math.Abs(hintPos[i, 0] - x) < 0.5f && System.Math.Abs(hintPos[i, 1] + 0.5f - y) < 0.5f)
            {
                return hints[i];
            }
        }
        return null;
    }







    // Update is called once per frame
    void Update()
    {
        
    }

}