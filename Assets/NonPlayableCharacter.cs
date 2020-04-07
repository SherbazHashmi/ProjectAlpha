using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { LEFT, RIGHT };

public class NonPlayableCharacter : MonoBehaviour
{
    public bool isFriendly;
    public string characterName;
    public bool isRanged;
    [SerializeField] float initialHealth;
    [SerializeField] float initialEnergy;
    private bool isDead;
    private int dialogueToggledTimes; // Number of times dialogue triggered
    public List<string> dialogues;
    public float interactionRange = 6;
    private DialoguePopup dialoguePopup;
    public Direction facingDirection = Direction.RIGHT;
    

    private float health, energy;
    private QuantumController character;
    // Start is called before the first frame update
    void Start()
    {
        this.health = initialHealth;
        this.energy = initialEnergy;
        dialoguePopup = FindObjectOfType<DialoguePopup>();
        if (dialogues != null)
        {
            dialogues.Add("");
        }
        character = FindObjectOfType<QuantumController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialoguePopup.isVisible && !isInRange(character.transform.position))
        {
            dialoguePopup.hide();
        }

    }

    public void Attack(float damage, Direction playerFacingDirection)
    {
        if(this.health > 0)
        {
            this.health -= damage;
            if(playerFacingDirection == Direction.LEFT)
            {
                this.gameObject.transform.Translate(new Vector3(-1.5F, 1F));

            } else
            {
                this.gameObject.transform.Translate(new Vector3(1.5F, 1F));

            }
        } 

        if(!isDead && health <= 0)
        {
            isDead = true;
            this.gameObject.transform.Rotate(new Vector3(180, 0));
        }
    }

    public bool isInRange(Vector3 playerPosition)
    {
        float npcPos = transform.position.x;
        float playerPos = playerPosition.x;
        return (npcPos - interactionRange < playerPos && npcPos + interactionRange > playerPos);
    }


    public bool isFacing(Direction playerFacingDirection, Vector3 playerPosition)
    {
        // Determine which side of player I am on
        Vector3 differenceBetweenNPCAndPlayer = playerPosition - transform.position;
        Direction directionRelativeToPlayer = differenceBetweenNPCAndPlayer.x > 0 ? Direction.LEFT : Direction.RIGHT;
        return playerFacingDirection == directionRelativeToPlayer;
    }

    public void interact()
    {
        if(dialogues != null && dialogues.Count > 0)
        {
            dialoguePopup.show();
            deliverDialogue();
        }
    }

    public void deliverDialogue()
    {
        int dialogueIndex = dialogueToggledTimes % dialogues.Count;
        if (dialogueIndex == dialogues.Count - 1)
        {
            dialoguePopup.hide();
        } else
        {
            string currentDialogue = dialogues[dialogueIndex];
            dialoguePopup.displayText(characterName, currentDialogue, "");
        }
       
        dialogueToggledTimes++;
    }
}
