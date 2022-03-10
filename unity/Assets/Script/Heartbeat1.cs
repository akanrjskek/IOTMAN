﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Text를 쓰실거면 추가해주세요
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization.Attributes;
public class Heartbeat1 : MonoBehaviour
{
    public Material mat;
    public Text scoreText;
    int num = 0;
    string connectionString = "mongodb://localhost:27017";
    void Start()
    {
        InvokeRepeating("heart", 1, 3);
    }

    void heart()
    {
        var client = new MongoClient(connectionString);
        var server = client.GetServer();
        Debug.Log(server);
        server.Connect();
        var database = server.GetDatabase("yeonghun");
        var shopCollection = database.GetCollection("heartbeat1");
        num = int.Parse(shopCollection.FindOne().GetValue("heart").ToString());        
        scoreText.text = "환자1의 BPM : " + 87;
        shopCollection.Drop();
    }
    void Update()
    {

    }
}