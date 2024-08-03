using NoteInfo;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoteInfo : MonoBehaviour
{
    public class Note
    {
        public Vector3 position;

        public bool isGenerate;
        public int laneNum;

        public void Generate()
        {
            if (this.isGenerate)
            {
                GameObject noteObj = Resources.Load<GameObject>("note");
                Transform parent = GameObject.Find("Lane_" + laneNum).transform;

                GameObject notes = Instantiate(noteObj, parent);
                notes.transform.localPosition = position;
            }
        }
    }

    public List<List<Note>> note = new List<List<Note>>();

    public List<List<Note>> InitializeNotes()
    {
        for (int i = 0; i < Constants.LaneCount; i++)
        {
            note.Add(new List<Note>());
            for (int j = 0; j < Constants.NoteCount; j++)
            {
                Note note = new Note();
                note.isGenerate = UnityEngine.Random.Range(0, 2) == 0;

                this.note[i].Add(note);
            }
        }

        return note;
    }
    public void Awake()
    {

        InitializeNotes();
    }
}
