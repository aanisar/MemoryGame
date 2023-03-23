using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{

//identifying the objects and define the variables
[SerializeField] private GameObject image_blank;
[SerializeField] private GameController gameController;



public void OnMouseDown(){
    if(image_blank.activeSelf && gameController.canOpen)
    {
        //it flips the card
        image_blank.SetActive(false);
        gameController.imageOpened(this);
    }
}

//it identify the sprite id and returns it
private int _spriteId;
public int spriteId{
    get{return _spriteId;}

}
public void ChangeSprite(int id, Sprite image)
{
    _spriteId = id;
    GetComponent<SpriteRenderer>().sprite = image;
}

    public void Close()
    {
        //it flip back to unknown side
        image_blank.SetActive(true);
    }
}
