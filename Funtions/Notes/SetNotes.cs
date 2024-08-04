using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

using static CreateNoteInfo;

public class SetNotes : MonoBehaviour
{

    private List<List<Note>> allNotes;
    public List<Note> myNote;

    private int laneNum;

    private void Start()
    {
        myNote = GetThisLaneNote();
        GenerateNote(myNote);
    }

    public void GenerateNote(List<Note> notes)
    {
        for (int i = 0; i < myNote.Count; i++)
        {
            float firstPosY = (float)(2.53 + i * 0.4);

            myNote[i].position = new Vector3(0, firstPosY);
            myNote[i].laneNum = this.laneNum;
            myNote[i].Generate();
        }
    }

    public List<Note> GetThisLaneNote()
    {
        allNotes = GameObject.Find("NoteInfo").gameObject.GetComponent<CreateNoteInfo>().note;
        laneNum = int.Parse(GetLaneNumToString(gameObject.name));

        return allNotes[laneNum];
    }

    public string GetLaneNumToString(string laneName)
    {
        string laneNum = Regex.Match(laneName, "\\d+").Value;

        return laneNum;
    }
}
