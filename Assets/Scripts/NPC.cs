using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    private int score;
    private bool[] booleans = new bool[7] {false,false,false,false,false,false,false};

    [TextArea(5, 10)]
    public string Name;
    // SCORE
    public Text scoreText;
    public int objetiveNumber;
    public Text objectiveText; //Textos dos objetivos
    public GameObject objBackground;
    public Text NextLevel;
    public string[] sentences;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
    
    void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
            //score
            if(objetiveNumber!= -1 && !booleans[objetiveNumber-1]){
                if(objetiveNumber >= 5){
                    score = Convert.ToInt32(scoreText.text);
                    score += 20;
                }                
                else{
                    score = Convert.ToInt32(scoreText.text);
                    score += 10;
                }
                scoreText.text = score.ToString();
                UpdateObjectivesText(objetiveNumber);
                booleans[objetiveNumber-1] = true;
            }
            if(score >= 100){
            	NextLevel.text = "\n\n\n\n\n\nVocê Ganhou!\nPressione P para o próximo nível";
            	objBackground.SetActive(true);
            }
        }
        // if(booleans[0] && booleans[1] && booleans[2] && booleans[3] 
        // 	&& booleans[4] && booleans[5] && booleans[6]){
        	
        // }
    }

    public void UpdateObjectivesText(int objective){
        if(objective == 1)
            objectiveText.text = " ̶D̶e̶s̶c̶o̶b̶r̶i̶r̶ ̶o̶ ̶p̶a̶p̶i̶r̶o̶";
        else if(objective == 2)
            objectiveText.text = "\n ̶D̶e̶s̶c̶o̶b̶r̶i̶r̶ ̶h̶i̶e̶r̶ó̶g̶l̶i̶f̶o̶s̶";
        else if(objective == 3)
            objectiveText.text = "\n\n ̶D̶e̶s̶c̶o̶b̶r̶i̶r̶ ̶t̶ú̶m̶u̶l̶o̶ ̶d̶a̶ ̶r̶a̶i̶n̶h̶a̶";
        else if(objective == 4)
            objectiveText.text = "\n\n\n ̶D̶e̶s̶c̶o̶b̶r̶i̶r̶ ̶t̶ú̶m̶u̶l̶o̶ ̶d̶o̶ ̶r̶e̶i̶";
        else if(objective == 5)
            objectiveText.text = "\n\n\n\n ̶F̶a̶l̶a̶r̶ ̶c̶o̶m̶ ̶A̶l̶p̶h̶y̶s̶";
        else if(objective == 6)
            objectiveText.text = "\n\n\n\n\n ̶F̶a̶l̶a̶r̶ ̶c̶o̶m̶ ̶W̶h̶e̶a̶t̶l̶e̶y̶";
        else if(objective == 7)
            objectiveText.text = "\n\n\n\n\n\n ̶F̶a̶l̶a̶r̶ ̶c̶o̶m̶ ̶A̶k̶i̶r̶a̶";
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}