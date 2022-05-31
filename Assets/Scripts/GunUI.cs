using System;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
   [SerializeField] Text firingMode;

   public void SetFiringMode(Gun.FiringMode mode)
   {
      firingMode.text = $"(X) Mode: {mode.ToString()}";
   }
}
