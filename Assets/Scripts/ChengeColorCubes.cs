using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ChengeColorCubes : MonoBehaviour
{
    [SerializeField]
    private SpawnCube _spawnCube;

    [SerializeField]
    private float _delayBeforeColor = 0.2f;
    
   public void ChengeColor()
   {
       StartCoroutine(ChengeColorCube());
   }

   private IEnumerator ChengeColorCube()
   {
       var randomColor = Random.ColorHSV();

       foreach (var cubes in _spawnCube.Cubes)
       {
           cubes.GetComponent<Renderer>().material.color = randomColor;
           yield return new WaitForSeconds(_delayBeforeColor);
       }
   }
}


