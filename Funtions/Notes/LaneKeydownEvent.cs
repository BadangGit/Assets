using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using static CreateNoteInfo;

public class LaneKeydownEvent : MonoBehaviour
{
    private SpriteRenderer thisLane;
    private KeyCode laneKey;
    private int laneNumber;

    private int distance;

    private GameObject nearNote;
    private GameObject judgeLine;

    private string judgement;

    private Text textItem;
    private Color color;

    private Note note = new();

    private void Start()
    {
        laneNumber = int.Parse(Regex.Match(gameObject.name, "\\d+").Value);

        judgeLine = GameObject.Find("JudgeLine").gameObject;
        thisLane = gameObject.GetComponent<SpriteRenderer>();

        switch (laneNumber)
        {
            case 0:
                laneKey = KeyCode.D; break;
            case 1:
                laneKey = KeyCode.F; break;
            case 2:
                laneKey = KeyCode.J; break;
            case 3:
                laneKey = KeyCode.K; break;
        }
    }

    void Update()
    {
        nearNote = gameObject.transform.GetChild(0).gameObject;

        if (Input.GetKey(laneKey))
        {
            WhitenLaneColor();
        }

        if (Input.GetKeyUp(laneKey))
        {
            DarkenLaneColor();
        }

        if (Input.GetKeyDown(laneKey))
        {
            PressLine(nearNote);
        }
    }

    private void WhitenLaneColor()
    {
        thisLane.color = new Color32(255, 255, 255, 3);
    }

    private void DarkenLaneColor()
    {
        thisLane.color = new Color32(255, 255, 255, 0);
    }

    private void PressLine(GameObject nearNote)
    {


        int notePosY = (int)(nearNote.transform.position.y);
        int linePosY = (int)(judgeLine.transform.position.y);

        distance = Math.Abs(notePosY - linePosY);

        textItem = GameObject.Find("Text").GetComponent<Text>();

        if (distance < 200)
        {
            switch (distance)
            {
                case < 100:
                    judgement = "Perfect!";
                    color = Color.yellow; break;
                case < 200:
                    judgement = "Good";
                    color = Color.blue; break;
            }
            note.Break(nearNote);
            textItem.text = judgement;
            textItem.color = color;
        }
    }
}
