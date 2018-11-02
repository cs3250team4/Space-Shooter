using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Coal", "A piece of coal.",
            new Dictionary<string, int>
            {
                {"Coin Value", 5}
            })
            };

        items = new List<Item>() {
              new Item(1, "Gold", "A rare piece of gold.",
              new Dictionary<string, int>
              {
                  {"Coin Value", 10}
              })
              };

        items = new List<Item>() {
              new Item(2, "Asteroid", "A chunk of an asteroid.",
              new Dictionary<string, int>
              {
                  {"Coin Value", 2}
              })
              };

        items = new List<Item>() {
              new Item(3, "Scrap Metal", "A piece of scrap metal.",
              new Dictionary<string, int>
              {
                  {"Coin Value", 6}
              })
              };

        items = new List<Item>() {
              new Item(4, "Rare Metal", "A rare piece of metal.",
              new Dictionary<string, int>
              {
                  {"Coin Value", 8}
              })
              };

        items = new List<Item>() {
                new Item(5, "Rare Rock", "A rare piece of rock.",
                new Dictionary<string, int>
                {
                  {"Coin Value", 10}
                })
                };

        items = new List<Item>() {
               new Item(6, "Rock", "A common piece of rock.",
               new Dictionary<string, int>
               {
                  {"Coin Value", 1}
               })
               };


    }
}
