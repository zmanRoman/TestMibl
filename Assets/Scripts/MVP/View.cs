using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MVP
{
   public abstract class View : MonoBehaviour
   {
      public Joystick Joystick => joystick;
      [SerializeField] private Joystick joystick;
      [SerializeField] private GameObject stateYouLose;
      [SerializeField] private GameObject stateStart;
      [SerializeField] private Button start;
      [SerializeField] private Button restart;
      [SerializeField] private TextMeshProUGUI textTimerLose;
      [SerializeField] private TextMeshProUGUI textTimer;
      
      protected Presenter Presenter;
      public void Init(Presenter presenter)
      {
         Presenter = presenter;
         stateStart.SetActive(true);
         stateYouLose.SetActive(false);
         
         restart.onClick.AddListener(Presenter.OnRestartButtonClicked);
         start.onClick.AddListener(Presenter.OnStartButtonClicked);
      }

      public void StartGame()
      {
         stateStart.SetActive(false);
         stateYouLose.SetActive(false);
      }

      public void DisplayYouLose(string time)
      {
         stateYouLose.SetActive(true);
         textTimerLose.text = time;
      }

      public void DisplayTimer(string time)
      {
         textTimer.text = time;
      }
      
      private void OnDisable()
      {
         restart.onClick.RemoveListener(Presenter.OnRestartButtonClicked);
         start.onClick.RemoveListener(Presenter.OnStartButtonClicked);
      }
      
   }
}
