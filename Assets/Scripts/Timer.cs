using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
   private float _time;

   private IEnumerator _countdown;
   private MonoBehaviour _context;

   public event Action<float> HasBeenUpdated;

   public Timer(MonoBehaviour context) => _context = context;

   public void StartTime()
   {
      _time = 0;
      _countdown = Countdown();
      _context.StartCoroutine(_countdown);
   }

   public void StopTime()
   {
      if(_countdown != null)
         _context.StopCoroutine(_countdown);
   }

   private IEnumerator Countdown()
   {
      while (true)
      {
         _time += Time.deltaTime;
         HasBeenUpdated?.Invoke(_time);
         yield return null;
      }
   }
}
