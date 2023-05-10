using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] float currentCash;

    public float CurrentCash {get => currentCash; set => currentCash = value; }
}
