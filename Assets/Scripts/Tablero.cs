using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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

    public Transform cells;
    public List<Events> cellList;
    public List<TokenPos> tokens;
    public float minXLimit;
    public float maxXLimit;
    public float minZLimit;
    public float maxZLimit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            cellList.Clear();
            foreach (Transform transform in cells)
            {
                Events events = transform.GetComponent<Events>();
                if (events != null)
                {
                    cellList.Add(events);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitialiseToken(Token token)
    {
        tokens.Add(new TokenPos(token, 0));
        token.transform.DOMove(cellList[0].transform.position, 0.1f).Play();
    }


    public void MoveToken(Token token, int movement, bool absolute = false)
    {
        //Debug.Log("Moving");
        for (int i = 0; i < tokens.Count; i++)
        {
            TokenPos tokenPos = tokens[i];
            if (tokenPos.token == token)
            {
                //Debug.Log(tokenPos.token);
                //Debug.Log(tokenPos.pos);

                int targetPos = tokenPos.pos + movement;
                if (absolute)
                {
                    targetPos = movement;
                }
                while (targetPos >= cellList.Count)
                {
                    targetPos -= cellList.Count;
                }
                tokenPos.pos = targetPos;
                //Debug.Log(targetPos);
                token.MoveTo(cellList[targetPos].transform);
                tokens[i] = tokenPos;
                cellList[targetPos].Score(token.player);
                break;
            }
        }
    }




}
