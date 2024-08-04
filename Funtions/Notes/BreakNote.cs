using UnityEngine;
using static CreateNoteInfo;

public class BreakNote : MonoBehaviour
{
    Vector3 pos;

    Note note = new();

    void FixedUpdate()
    {
        pos = this.transform.position;
        if (pos.y < -510)
        {
            note.Break(gameObject);
        }
    }
}
