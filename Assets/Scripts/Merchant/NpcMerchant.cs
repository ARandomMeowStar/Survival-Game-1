using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMerchant : MonoBehaviour
{
  public ItemSO[] Items => items;
  [SerializeField] private ItemSO[] items;
}
