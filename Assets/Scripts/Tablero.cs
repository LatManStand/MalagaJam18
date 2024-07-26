using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct TokenPos
{
    public int pos;
    public Token token;

    public TokenPos(Token token = null, int pos = 0)
    {
        this.token = token;
        this.pos = pos;
    }
}


public class Tablero : MonoBehaviour
{
    public static Tablero instance;

    public List<Events> cellList;
    public List<TokenPos> tokens;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitialiseToken(Token token)
    {
        tokens.Add(new TokenPos(token, 0));
        token.transform.Translate(cellList[0].transform.position);
    }


    public void MoveToken(Token token, int movement, bool absolute = false)
    {
        Debug.Log("Moving");
        TokenPos tokenPos = tokens[0];
        foreach (TokenPos pos in tokens)
        {
            if (pos.token == token)
            {
                tokenPos = pos;
            }
        }
        int targetPos = tokenPos.pos + movement;
        if (absolute)
        {
            targetPos = movement;
        }
        while (targetPos > cellList.Count)
        {
            targetPos -= cellList.Count;
        }
        token.MoveTo(cellList[targetPos].transform);
    }




}
