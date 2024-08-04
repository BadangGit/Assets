using NoteInfo;
using UnityEngine;
using static CreateNoteInfo;

public class DropNotes : MonoBehaviour
{
    Rigidbody2D rigid;

    private Vector3 pos;
    private Note note = new();

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, Constants.noteVelocity);
    }

    private void Update()
    {
        pos = this.transform.position;

        if (pos.y < -540)
        {
            note.Break(gameObject);
        }
    }
}
