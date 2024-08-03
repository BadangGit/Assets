using NoteInfo;
using UnityEngine;

public class DropNotes : MonoBehaviour
{
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, Constants.noteVelocity);
    }
}
