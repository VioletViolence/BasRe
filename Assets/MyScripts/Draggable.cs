using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    Vector3 dist;
    float posX;
    float posY;
    float posZ;
    float StartY;
    public string PreviousTag;

    void OnMouseDown()
    {
        StartY = transform.position.y;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posZ = Input.mousePosition.z - dist.z;
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;

    }

    void OnMouseDrag()
    {
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 curPos = new Vector3(disX, disY, disZ);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        worldPos.y = StartY;
        transform.position = worldPos;
    }

    private void OnMouseUp()
    {
        gameObject.tag = PreviousTag;
        gameObject.GetComponent<Attack_Manager>().enabled = true;
        gameObject.GetComponent<Melee>().enabled = true;
    }
}
