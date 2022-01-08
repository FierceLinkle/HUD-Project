using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveset : MonoBehaviour
{
    public Image Move1;
    public Image Move2;
    public Image Move3;
    public Image Move4;
    public Image Move5;
    public Image Move6;

    [SerializeField] private Sprite[] MovesetSprites;

    // Start is called before the first frame update
    void Start()
    {
        Move1.sprite = MovesetSprites[0];
        Move2.sprite = MovesetSprites[1];
        Move3.sprite = MovesetSprites[2];
        Move4.sprite = MovesetSprites[3];
        Move5.sprite = MovesetSprites[4];
        Move6.sprite = MovesetSprites[9];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Add skills via level up

    //Change skills option
}
