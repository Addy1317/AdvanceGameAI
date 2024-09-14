using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : MonoBehaviour
{
    public GameObject personPrefab;
    public int populationSize = 10;
    List<GameObject> population = new List<GameObject >();
    public static float elasped = 0;

    private int trialTime = 10;
    private int generation = 1;

    GUIStyle guistyle = new GUIStyle();

    private void OnGUI()
    {
        guistyle.fontSize = 50;
        guistyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10,10,100, 20), "Generation:" + generation, guistyle);
        GUI.Label(new Rect(10, 65, 100, 20),"Trial Time: " + (int)elasped,guistyle);
    }
    private void Start()
    {
        for(int i = 0; i < populationSize; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f),0);
            GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
            go.GetComponent<DNA>().r = Random.Range(0.0f,1.0f);
            go.GetComponent<DNA>().g = Random.Range(0.0f,1.0f);
            go.GetComponent<DNA>().b = Random.Range(0.0f,1.0f);
            population.Add(go);
        }
    }

    private void Update()
    {
        elasped += Time.deltaTime;

        if(elasped > trialTime)
        {
            BreedNewPopulation();
            elasped = 0;
        }
    }
}
