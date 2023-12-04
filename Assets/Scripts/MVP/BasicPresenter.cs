namespace MVP
{
    public class BasicPresenter : Presenter
    {
        public BasicPresenter(Model model) : base(model)
        {
        }
        
        public override void OnRestartButtonClicked()
        {
            OnStartButtonClicked();
        }

        public override void OnStartButtonClicked()
        {
            Timer = new Timer(Model);
            StartTimer();
            Model.StartGame();
            OnStartGame();
        }

        public override void StartTimer()
        {
            Timer.StartTime();
            Timer.HasBeenUpdated += Model.SetTime;
        }
        
        public override void StopTimer()
        {
            Timer?.StopTime();
            if (Timer != null) 
                Timer.HasBeenUpdated -= Model.SetTime;
            
            Model.SetStateLose();
            OnStopGame();
        }
    }
}
