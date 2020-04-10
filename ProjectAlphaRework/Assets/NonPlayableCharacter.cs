using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { LEFT, RIGHT };

// private Vector3 knockBackEffect = QuantumAbilityController.knockBackEffect;

public class NonPlayableCharacter : MonoBehaviour
{
    public bool isFriendly;
    public string name;
    public bool isRanged;
    [SerializeField] float initialHealth;
    [SerializeField] float initialEnergy;
    public bool isDead;

    public Direction facingDirection = Direction.RIGHT;

    private float health, energy;
    private QuantumController character;
    // Start is called before the first frame update
    void Start()
    {
        this.health = initialHealth;
        this.energy = initialEnergy;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack(float damage)
    {
        if(this.health > 0)
        {
            this.health -= damage;
            this.gameObject.transform.Translate(QuantumAbilityController.knockBackEffect);
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

        return (npcPos - 1.6 < playerPos && npcPos + 1.6 > playerPos);
    }

    public bool isFacing(Direction playerFacingDirection, Vector3 playerPosition)
    {
        // Determine which side of player I am on
        Vector3 differenceBetweenNPCAndPlayer = playerPosition - transform.position;
        Direction directionRelativeToPlayer = differenceBetweenNPCAndPlayer.x > 0 ? Direction.LEFT : Direction.RIGHT;
        Debug.Log("I am to the "+ directionRelativeToPlayer + " of the player.");
        return playerFacingDirection != facingDirection;
    }


}
