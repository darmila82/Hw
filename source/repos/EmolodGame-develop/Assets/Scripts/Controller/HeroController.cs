using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Entity.Characters;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    public List<Character> heroList;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 

        this.heroList = new List<Character>();
        //this.heroList.Add(new Character());
    }

    void Update()
    {
        
    }
}
