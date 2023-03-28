using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private ItemScriptable itemData;

    [SerializeField]
    private RectTransform itemRecttrasnform;

    [SerializeField]
    private Image itemImg;

    #region
    private void Start()
    {
        itemRecttrasnform.localScale = Vector3.one;
        itemRecttrasnform.anchoredPosition = Vector2.zero;

        InitItemData();
    }

    private void Update()
    {

    }

    #endregion


    private void InitItemData()
    {
        itemImg.sprite = itemData.IconSprite;
    }
}
