using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationTrigger : MonoBehaviour
{
    [SerializeField] GameObject objectToTrigger;
    private TranslateObject translateObject;
    // Start is called before the first frame update
    void Start()
    {
        translateObject = objectToTrigger.GetComponent<TranslateObject>();
        translateObject.move();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
