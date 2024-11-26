using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Shop : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI Text;
    public float cash = 5;

    // Start is called before the first frame update
    void Start()
    {
        Text = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = cash.ToString("F1");
    }
}
