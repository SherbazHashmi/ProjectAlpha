using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

[AddComponentMenu("Project Alpha/Scripts")]



public class QuantumJump : CharacterJump
{

    public QuantumJump() {
        _doubleJumping = true;
        NumberOfJumps = 1;
        JumpIsProportionalToThePressTime = false;
    }

}
