using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int selectedZombiePosition;
    public GameObject selectedZombie;
    public List<GameObject> zombies;

    public Vector3 defaultSize = new Vector3(1, 1, 1);
    public Vector3 selectedSize = new Vector3(1.5f, 1.5f, 1.5f);

    public Text text;
    public int score = 0;


    void Start()
    {
        SelectZombie(zombies[0], 0);

        text.text = "Score: " + score;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { ShiftLeft(); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { ShiftRight(); }

        if (Input.GetKeyDown(KeyCode.UpArrow)) { PushUp(); }

    }

    void SelectZombie(GameObject newZombie, int newPosition)
    {
        // Set current zombie back to default scale
        selectedZombie.transform.localScale = defaultSize;

        selectedZombiePosition = newPosition;

        //set new zombie scale
        selectedZombie = newZombie;
        selectedZombie.transform.localScale = selectedSize;
    }

    void ShiftLeft()
    {
        if (selectedZombiePosition == 0) {
            SelectZombie(zombies[3], 3);
        }
        else
        {
            SelectZombie(zombies[selectedZombiePosition - 1], selectedZombiePosition - 1);
        }
    }

    void ShiftRight()
    {
        if (selectedZombiePosition == 3)
        {
            SelectZombie(zombies[0], 0);
        }
        else
        {
            SelectZombie(zombies[selectedZombiePosition + 1], selectedZombiePosition + 1);
        }
    }

    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, 10), ForceMode.Impulse);
    }


    public void AddScore()
    {
        score += 1;
        text.text = "Score: " + score;
    }

}
