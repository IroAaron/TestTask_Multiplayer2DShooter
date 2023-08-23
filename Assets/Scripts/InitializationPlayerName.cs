using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitializationPlayerName : MonoBehaviour
{
    [SerializeField] private TextMeshPro PlayerName;

    void Start()
    {
        PlayerName.text = GetComponent<CharacterStats>().PlayerName;
    }
}
