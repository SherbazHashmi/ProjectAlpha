using UnityEngine;
using MoreMountains.Tools;
using System.Collections;

namespace MoreMountains.CorgiEngine
{
    public class NPCHealthPower : Health
    {
        [SerializeField] int powerToAdd;

	
        public override void Kill()
        {
            // we make our handheld device vibrate
            if (VibrateOnDeath)
            {
#if UNITY_ANDROID || UNITY_IPHONE
                    Handheld.Vibrate(); 
#endif
            }

            // we prevent further damage
            DamageDisabled();

            // instantiates the destroy effect
            if (DeathEffect != null)
            {
                GameObject instantiatedEffect = (GameObject)Instantiate(DeathEffect, transform.position, transform.rotation);
                instantiatedEffect.transform.localScale = transform.localScale;
            }

            // Adds points if needed.
            if (PointsWhenDestroyed != 0)
            {
                // we send a new points event for the GameManager to catch (and other classes that may listen to it too)
                MMEventManager.TriggerEvent(new CorgiEnginePointsEvent(PointsMethods.Add, PointsWhenDestroyed));
            }

            // Adds power if needed

            if (powerToAdd != 0) {
                // we send a new power event for the GameManager to catch
                MMEventManager.TriggerEvent(new PowerEvent(PowerEventType.Add, powerToAdd));
            }

            // if we have a controller, removes collisions, restores parameters for a potential respawn, and applies a death force
            if (_controller != null)
            {
                // we make it ignore the collisions from now on
                if (CollisionsOffOnDeath)
                {
                    _controller.CollisionsOff();
                    if (_collider2D != null)
                    {
                        _collider2D.enabled = false;
                    }
                }

                // we reset our parameters
                _controller.ResetParameters();

                // we apply our death force
                if (DeathForce != Vector2.zero)
                {
                    _controller.GravityActive(true);
                    _controller.SetForce(DeathForce);
                }
            }

            if (OnDeath != null)
            {
                OnDeath();
            }

            // if we have a character, we want to change its state
            if (_character != null)
            {
                // we set its dead state to true
                _character.ConditionState.ChangeState(CharacterStates.CharacterConditions.Dead);
                _character.Reset();

                // if this is a player, we quit here
                if (_character.CharacterType == Character.CharacterTypes.Player)
                {
                    return;
                }
            }
            // finally we destroy the object
            DestroyObject();
        }
    }
}