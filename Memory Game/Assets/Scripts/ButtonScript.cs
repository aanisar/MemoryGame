using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //identifying the objects and define the variables
    [SerializeField] private GameController gameController;
    [SerializeField] private string functionOnClick;


    // it creates the animation when the user click to reset
    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if(sprite != null)
        {
            sprite.color = Color.green;
        }
    }

    public void OnMouseDown(){
        transform.localScale = new Vector3(0.12f, 0.12f, 1.0f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.5f);
        if(gameController != null)
        {
            gameController.SendMessage(functionOnClick);
        } 
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null){
            sprite.color = Color.white;
        }
    }
}
