//vi bruger system.collections pakken
using System.Collections;
//vi bruger system.collections.generic pakken
using System.Collections.Generic;
//vi bruger TMPro pakken
using TMPro;
//vi bruger unityengine pakken
using UnityEngine;

//vores program består af en class, som hedder det samme som vores fil når vi programmerer i unity
public class Counter : MonoBehaviour
{
    //vi laver en TMP_Text varibel, text, som er privat
    private TMP_Text text;

    //vi laver en bool varibel, finished, som er public, men bliver gemt fra inspectoren
    [HideInInspector]
    public bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        //TryGetComponent returnerer en true/false værdi alt efter om den kan få fat på et component af den givne type
        //Den givne type er typen af den variabel du giver funktionen, her text, og hvis funktionen finder et component af typen, giver den variablen den værdi
        //hvis koden ikke for fat i det rigtige component, kør et stykke kode
        if (!TryGetComponent(out text))
        {
            //skriv en fejl i console
            Debug.LogError("Could not find TMP_Text component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //hvis finished ikke er true, kør et stykke kode
        if (!finished)
        {
            //sæt text variablens text felt til at være "Timer: " + den totale tid siden spillet blev startet, lavet om til en string med 1 decimal tal (1 tal efter komma)
            text.text = "Timer: " + Time.time.ToString("F1");
        }
    }
}