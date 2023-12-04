using MVP;
using Spawners;
using UnityEngine;

public class GameController : MonoBehaviour
{
   [SerializeField] private OrdinaryView ordinaryView;
   [SerializeField] private ModelEasy modelEasy;
   [SerializeField] private ModelHard modelHard;
   [SerializeField] private bool isHard;

   [SerializeField] private Player player;
   [SerializeField] private Spawner enemySpawner;
   [SerializeField] private Spawner mineSpawner;
   private void Awake()
   {
      View viewPrefab = ordinaryView;
      var view = Instantiate(viewPrefab);

      Model modelPrefab = isHard ? modelHard :modelEasy;
      var model = Instantiate(modelPrefab);
      
      Presenter presenter = new BasicPresenter(model);

      model.Init(view);
      view.Init(presenter);
     
      player.Init(model.GetConfig().SpeedPlayer);
      player.InitJoystick(view.Joystick);
      player.Collision += presenter.StopTimer;

      enemySpawner.Init(model.GetConfig(), player.transform);
      presenter.StartGame += enemySpawner.Spawn;
      presenter.StopGame += enemySpawner.StopSpawn;
      
      mineSpawner.Init(model.GetConfig());
      presenter.StartGame += mineSpawner.Spawn;
      presenter.StopGame += mineSpawner.StopSpawn;
   }
}
