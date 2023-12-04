using System;
using UnityEngine;

namespace MVP
{
    public abstract class Model : MonoBehaviour
    {
        [SerializeField]private Config.Config config;
        private View view;
        private float time;

       public void Init (View view)
       {
           this.view = view;
       }
    
       public void SetStateLose()
       {
           var timeText = $"{(int)time / 60:00}:{(int)time % 60:00}";
           view.DisplayYouLose(timeText);
       }

       public void StartGame()
       {
           view.StartGame();
       }

       public void SetTime(float time)
       {
           this.time = time;
           var timeText = $"{(int)this.time / 60:00}:{(int)this.time % 60:00}";
           view.DisplayTimer(timeText);
       }

       public Config.Config GetConfig()
       {
           return config;
       }
    }
}
