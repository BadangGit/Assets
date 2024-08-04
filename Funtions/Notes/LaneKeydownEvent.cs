using System.Text.RegularExpressions;
using UnityEngine;

public class LaneKeydownEvent : MonoBehaviour
{
    private SpriteRenderer thisLane;
    private KeyCode laneKey;
    private int laneNumber;

    private void Start()
    {
        laneNumber = int.Parse(Regex.Match(gameObject.name, "\\d+").Value);

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
        if (Input.GetKey(laneKey))
        {
            WhitenLaneColor();
        }

        if (Input.GetKeyUp(laneKey))
        {
            DarkenLaneColor();
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
}
