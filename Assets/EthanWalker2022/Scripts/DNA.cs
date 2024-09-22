using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMovement
{
    public class DNA : MonoBehaviour
    {
        List<int> genes = new List<int>();
        int dnalength = 0;
        int maxValues = 0;

        public DNA(int l, int v)
        {
            dnalength = 1;
            maxValues = v;
            SetRandom();
        }

        public void SetRandom()
        {
            genes.Clear();
            for (int i = 0; i < dnalength; i++)
            {
                genes.Add(Random.Range(0, maxValues));
            }
        }

        public void SetInt(int pos, int Value)
        {
            genes[pos] = Value;
        }

        public void Combine(DNA d1, DNA d2)
        {
            for (int i = 0; i < dnalength; i++)
            {
                if(i < dnalength/2.0)
                {
                    int c = d1.genes[i];
                    genes[i] = c;
                }
                else
                {
                    int c  = d2.genes[i];
                    genes[i] = c;
                }
            }
        }

        public void Mutate()
        {
            genes[Random.Range(0, dnalength)] = Random.Range(0, maxValues);
        }

        public int GetGene(int pos)
        {
            return genes[pos];
        }
    }
}