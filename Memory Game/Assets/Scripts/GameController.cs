using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    // creates the columns and rows
    public const int columns = 4;
    public const int rows = 4;

    // creates spaces between the colomn and row
    public const float Xspace = 3f;
    public const float Yspace = -2f;

    //identifying the objects and define the variables
    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

    //it will automatically creates column and row randommly 
    private int[] Randomiser(int[] locations) {
        int[] array = locations.Clone() as int[];
        for(int i=0; i < array.Length; i++) {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {

        // setting up the positions
        int[] locations = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7}; 
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        // assign the images into the position
        for(int i = 0; i < columns; i++)
        {
            for(int j=0; j <rows; j++)
            {
               MainImageScript gameImage;
                if(i==0 && j ==0)
                {
                    gameImage = startObject;
                }
                else
                {
                    {
                        gameImage = Instantiate(startObject) as MainImageScript;
                    }

                    int index = j * columns + i;
                    int id = locations[index];
                    gameImage.ChangeSprite(id, images[id]);

                    float positionX = (Xspace * i) + startPosition.x;
                    float positionY = (Yspace * j) + startPosition.y;

                    gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                }
            }
        }

    }

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    // defining the variables for score and attempts
    private int score = 0;
    private int attempts = 0;


    // identifying the objects from the scene builder
    [SerializeField] private TextMesh ScoreText;
    [SerializeField] private TextMesh AttemptsText;

    public bool canOpen
    {
        get {return secondOpen == null;}
    }


    public void imageOpened(MainImageScript startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    } 


    private IEnumerator CheckGuessed(){

        // it increase the score by one when two cards are matched
        if(firstOpen.spriteId == secondOpen.spriteId){
            score++;
            ScoreText.text = "Score: " + score;
        }
        else{

            // itll flip back the opened cards since both arent matching
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();
        }

        //it increases the attempt by one
        attempts++;
        AttemptsText.text = "Attemps: " + attempts;

        firstOpen = null;
        secondOpen = null;
    }

    // it restarts the game
    public void Restart(){
        SceneManager.LoadScene("MainScene");

    }

}
