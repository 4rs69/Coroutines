using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
   public IReadOnlyList<GameObject> Cubes => _cubes;

   [SerializeField]
   private GameObject _cube;

   [SerializeField]
   private float _spawnInterval = 0.04f;
   
   private  List<GameObject> _cubes = new();

   private int _rows = 20;
   private int _column = 20;

   private float _SpacingBetweenCubes = 0.05f;
   private float _scaleCube = 0.25f;

   [SerializeField]
   private Vector2 _nextPositionCube;
   
   private void Start()
   {
      StartCoroutine(SpawnCubes());
   }
   
   private IEnumerator SpawnCubes()
   {
      for (var i = 0; i < _rows; i++)
      {
         for (var j = 0; j < _column; j++)
         {
            var nextPositionCubeX = j * _scaleCube + j * _SpacingBetweenCubes;
            var nextPositionCubeY = i * _scaleCube + i * _SpacingBetweenCubes;
            var nextPositionCube =  _nextPositionCube +new Vector2(nextPositionCubeX,-nextPositionCubeY);

            _cubes.Add(Instantiate(_cube, nextPositionCube, Quaternion.identity));
            
            yield return new WaitForSeconds(_spawnInterval);
         }
      }
   }
   
   
}

