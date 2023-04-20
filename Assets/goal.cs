using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public int playerOneScore=0;
    public int playerTwoScore=0;

    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The trigger " + this.gameObject.name + " has been triggered");

        if (other.gameObject.name == "Ball")
        {
            if (this.gameObject.name == "goalpost-background-left")
            {
                Debug.Log(++playerTwoScore);
                // un obiect nou de scor sa apara
                // mingea sa se reponeze
            }
            if (this.gameObject.name == "goalpost-background-right")
            {
                Debug.Log(++playerOneScore);
            }
        }
    }

    
}
