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
        // Item = ������ ���̺��� �������� ���� ����
        // Price = ������ Ƽ����� ���� ���� ����

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
