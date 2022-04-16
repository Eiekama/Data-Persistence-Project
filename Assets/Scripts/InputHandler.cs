using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputHandler : MonoBehaviour
{

    TMP_InputField Input;

    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponent<TMP_InputField>();
        Input.characterLimit = 20;
    }
}
