using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallScript : MonoBehaviour
{
    public GameObject block;
    private List<Vector2Int> posList;
    private List<Vector2Int> hintPos;
    private Vector2 endPos;

    private string[] hints;

    // Start is called before the first frame update
    void Start()
    {
        Level.LoadLevels();
        Level level = Level.GetRandomLevel();
        posList = level.wallsPos;
        hintPos = level.hintsPos;
        endPos = new(level.endPos[0], level.endPos[1]);
        hints = level.hints;

        for (int i = 0; i < posList.Count; i++)
        {
            Instantiate(block, new Vector3(posList[i].x, posList[i].y+(float)0.5, 1), transform.rotation);
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
 
    public bool HasWall(Vector3 origin, Vector2 direction)
    {
        float x = origin.x + direction.x;
        float y = origin.y + direction.y;
        for (int i = 0; i < posList.Count; i++)
        {
            if (System.Math.Abs(posList[i].x - x) < 0.5f && System.Math.Abs(posList[i].y + 0.5f - y) < 0.5f)
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


    public string GetHint(Vector3 origin, Vector2 direction)
    {
        float x = origin.x + direction.x;
        float y = origin.y + direction.y;
        for (int i = 0; i < hintPos.Count; i++)
        {
            if (System.Math.Abs(hintPos[i].x - x) < 0.5f && System.Math.Abs(hintPos[i].y + 0.5f - y) < 0.5f)
            {
                return hints[i];
            }
        }
        return null;
    }

    public bool IsGoal(Vector3 origin, Vector2 direction)
    {
        float x = origin.x + direction.x;
        float y = origin.y + direction.y;
        return System.Math.Abs(endPos.x - x) < 0.5f && System.Math.Abs(endPos.y + 0.5f - y) < 0.5f;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

}

[System.Serializable]
public class Level
{
    private static readonly List<Level> levels = new();

    public List<Vector2Int> wallsPos = new();
    public List<Vector2Int> hintsPos = new();
    public Vector2Int endPos = new();
    public string[] hints;

    public static void LoadLevels()
    {
        TextAsset[] levelFiles = Resources.LoadAll<TextAsset>("Levels/");
        foreach (TextAsset levelFile in levelFiles)
        {
            Level level = JsonUtility.FromJson<Level>(levelFile.text);
            levels.Add(level);
        }
    }

    public static Level GetRandomLevel()
    {
        if (levels.Count == 0) return null;
        return levels[Random.Range(0, levels.Count)];
    }
}