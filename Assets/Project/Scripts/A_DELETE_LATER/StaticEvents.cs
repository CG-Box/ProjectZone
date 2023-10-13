using System;
using UnityEngine;

public class StaticEvents
{ 
    /*
    public class Health
    {
        public static Action<float> OnHealthChanged;
        public static Action<float> OnHealthDecreased;
        public static Action<float> OnHealthIncreased;
    }
    */
  public class Collecting
  {
    public static Action<Item> OnItemCollect;
  }

    /*
  public class Quest
  {  
    //public static Action<Quest> OnQuestComplete;
  }
  */

  public class Combat
  {
    public static Action<EnemyController> OnEnemyDeath;
    public static Action<string> OnPlayerDeath;
  }

  public class Spawning
  {
    public static Action<Transform> OnShootBullet;
  }

  public class Controls
  {
    public static Action OnUsePressed;
    public static Action OnUseHold;
    public static Action OnUseReleased;
  }

    /*
  public class Ui
  {
    public static Action OnMenuOpen;

    public static Action OnMenuClose;

    public static Action<int> OnLevelLoad;

    public static EventHandler OnExiTPressed; //EventArgs.Empty
    public static EventHandler<ButtonEventArgs> OnButtonPressed;

    public class ButtonEventArgs: EventArgs
    {
        public readonly int buttonCode;
        public ButtonEventArgs(int code) => buttonCode = code;
    }
  }
  */
}

// use example
// StaticEvents.Collecting.OnItemCollect += FunctionName; //register event
// StaticEvents.Collecting.OnItemCollect -= FunctionName; //unregister event
// StaticEvents.Collecting.OnItemCollect?.Invoke(new Item()); //call event
// StaticEvents.Ui.OnButtonPressed?.Invoke(this, new ButtonEventArgs(32));