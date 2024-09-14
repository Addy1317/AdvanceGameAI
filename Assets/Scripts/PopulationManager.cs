using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
        GameObject offspring = Instantiate(personPrefab, pos, Quaternion.identity);
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();

        //swap parent data

        if (Random.Range(0, 1000) > 5)
        {
            offspring.GetComponent<DNA>().r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
            offspring.GetComponent<DNA>().g = Random.Range(0, 10) < 5 ? dna1.r : dna2.g;
            offspring.GetComponent<DNA>().b = Random.Range(0, 10) < 5 ? dna1.r : dna2.b;
        }
        else
        {
            offspring.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
        }
        return offspring;
    }
     
    private void BreedNewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();

        //get rid of unfit individuals
        //List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNA>().timeToDie).ToList(); // normal order
        List<GameObject> sortedList = population.OrderByDescending(o => o.GetComponent<DNA>().timeToDie).ToList(); // decreased order

        population.Clear();

        //breed upper half of sorted list
        for (int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i+1]));
            population.Add(Breed(sortedList[i +1], sortedList[i]));
        }

        for(int  i = 0; i < population.Count; i++)
        {
            Destroy(sortedList[i]);
        }

        generation++;

    }
}
