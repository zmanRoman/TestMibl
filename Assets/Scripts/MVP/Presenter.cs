using System;

namespace MVP
{
    public abstract class Presenter
    {
        protected Model Model;
        protected Timer Timer;
        public event Action StartGame;
        public event Action StopGame;
        protected Presenter(Model model)
        {
            Model = model;
        }

        public abstract void OnRestartButtonClicked();
        public abstract void OnStartButtonClicked();
        public abstract void StartTimer();
        public abstract void StopTimer();

        protected void OnStartGame()
        {
            StartGame?.Invoke();
        }
        
        protected void OnStopGame()
        {
            StopGame?.Invoke();
        }
    }
}
