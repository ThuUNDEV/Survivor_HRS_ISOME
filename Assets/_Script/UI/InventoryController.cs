using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _slotTrasnforms;

    [SerializeField]
    private GameObject _itemSource;

    [SerializeField]
    private ItemDataScriptable _itemDataScriptable;

    [SerializeField]
    private Canvas _contentCanvas;

    [SerializeField]
    private Button _showInventoryButton;

    [SerializeField]
    private RectTransform _inventoryRecttransform;

    #region Unity Core

    private void OnEnable()
    {
        _showInventoryButton.onClick.AddListener(() => StartCoroutine(ShowInventory()));
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

    private readonly float _maximumWidthInventoryValue = 500f;
    private readonly float _timeOpenInventory = 1;

    /// <summary>
    /// M? b?ng Inventory
    /// </summary>
    private IEnumerator ShowInventory()
    {
        float countTimeOpenInventory = 0;

        while (countTimeOpenInventory <= _timeOpenInventory)
        {
            if (_inventoryRecttransform.sizeDelta.x <= _maximumWidthInventoryValue)
            {
                _inventoryRecttransform.sizeDelta += new Vector2(30, 0);
            }

            countTimeOpenInventory += Time.deltaTime;

            yield return null;
        }
    }

    private void InitItemInBag()
    {
        if (_slotTrasnforms.Length > 0)
        {
            for (int i = 0; i < _itemDataScriptable.TotalItemData; i++)
            {
                GameObject item = ObjectPool.Instance(_itemSource);

                item.transform.SetParent(_slotTrasnforms[i]);

            }
        }

    }


    #endregion

}
