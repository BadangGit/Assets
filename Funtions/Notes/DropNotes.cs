using NoteInfo;
using UnityEngine;
using UnityEngine.UI;
using static CreateNoteInfo;

public class DropNotes : MonoBehaviour
{
    Rigidbody2D rigid;

    private Vector3 pos;
    private Note note = new();

    private Text textItem;

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
            textItem = GameObject.Find("Text").GetComponent<Text>();

            textItem.text = "Miss";
            textItem.color = Color.red;
        }
    }
}
