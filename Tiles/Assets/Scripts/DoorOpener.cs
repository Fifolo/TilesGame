using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer door;
    public Sprite openedDoor;
    public Sprite clickedLever;

    private SpriteRenderer toggle;
    void Start()
    {
        toggle = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            toggle.sprite = clickedLever;
            door.sprite = openedDoor;
        }
    }
}
