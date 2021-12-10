using Root.General;
using Root.MainMenu.Scripts.Controls;
using Unity.Mathematics;
using UnityEngine;

namespace Root.TKD.Scripts
{
  public class Fighter : ControlledEntity
  {
    public enum HitHeight
    {
      NAN,
      Mid,
      High
    }
    
    public enum HitType
    {
      NAN,
      Punch,
      Kick,
      SpinningKick
    }

    [SerializeField] private bool ai;
    [SerializeField] private FloatParameter movementSpeed;

    private Transform cameraTransform;
    private Animator animator;

    [SerializeField] private Fighter opponent;

    Collider[] colliders = new Collider[1];

    [SerializeField] private Hitbox[] hitBoxes; // in order of range

    private bool[] blocking = new bool[2]; // whether blocked for a certain height 
    private HitHeight hh;
    private HitType ht;

    private int points = 0;

    private void Awake()
    {
      cameraTransform = Camera.main.transform;
      animator = GetComponent<Animator>();
    }

    private void Update()
    {
      if (ai) return;
      
      Quaternion rot = quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

      if (ConnectedController.left == Controller.ButtonState.Holding)
        animator.SetTrigger("Backward");

      if (ConnectedController.right == Controller.ButtonState.Holding)
        animator.SetTrigger("Forward");

      if (ConnectedController.primary == Controller.ButtonState.Pressed)
        animator.SetTrigger("Primary");
    }

    private void SetHitHeight(HitHeight hitHeight)
    {
      hh = hitHeight;
    }

    private void SetHitType(HitType hitType)
    {
      ht = hitType;
    }

    private void CheckHit(int hitBoxIndex)
    {
      int size = Physics.OverlapBoxNonAlloc(hitBoxes[hitBoxIndex].transform.position,
        hitBoxes[hitBoxIndex].transform.lossyScale, colliders, hitBoxes[hitBoxIndex].transform.rotation);

      if (size == 0) return;

      if (!opponent.GetHit(hh)) return;

      points += (int) hh - 1 + ((int) ht);

      hh = HitHeight.NAN;
      ht = HitType.NAN;
    }

    private bool GetHit(HitHeight hitHeight)
    {
      return !blocking[(int) hitHeight];
    }
  }
}