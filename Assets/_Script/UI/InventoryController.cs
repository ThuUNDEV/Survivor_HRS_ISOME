using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private Transform[] slotTrasnforms;

    [SerializeField]
    private GameObject itemSource;

    [SerializeField]
    private ItemDataScriptable itemDataScriptable;


    #region Unity Core

    private void OnEnable()
    {

    }

    private void Start()
    {
        InitItemInBag();
    }


    private void Update()
    {

    }


    #endregion


    #region Function

    private void InitItemInBag()
    {
        if (slotTrasnforms.Length > 0)
        {
            for (int i = 0; i < itemDataScriptable.TotalItemData; i++)
            {
                GameObject item = ObjectPool.Instance(itemSource);

                item.transform.SetParent(slotTrasnforms[i]);

            }
        }

    }


    #endregion

}
