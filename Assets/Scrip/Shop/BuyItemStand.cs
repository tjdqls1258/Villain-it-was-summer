using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemStand : MonoBehaviour
{
    public GameObject Texts;
    public int Price = 0;
    public TextMesh PriceText;
    private Item_Data Item;

    private void OnEnable()
    {
        SetRandomItem();
    }

    private void SetRandomItem()
    {
        // Item = 데이터 테이블에서 아이템을 랜덤 설정
        // Price = 아이템 티어에따라 가격 설정 가격

        PriceText.text = Price.ToString() + " $";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Texts.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Texts.SetActive(false);
    }
}
