using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GB_CreateJson : MonoBehaviour {
    public string jsonName = "WayPointPosition";
    List<PosJsonClass> posJsons;
    StringBuilder strBPos;
    string jsonData;
    bool isFirst = true;

    public GameObject[] btns;
    void Start() {
        foreach(var b in btns) {
            b.SetActive(true);
        }

        posJsons = new List<PosJsonClass>();
        strBPos = new StringBuilder();
    }
    public void AddPos() {
        float x, y, z;
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
        if (!isFirst)
            strBPos.Append("|");
        strBPos.Append($"{x},{y},{z}");
        isFirst = false;
        PosJsonClass pj = new PosJsonClass(strBPos.ToString());
        jsonData = ObjectToJson(pj);
        Debug.Log($"{jsonData} 입력");
    }
    public void SetJson() {
        //CreateJsonFile(Application.dataPath, jsonName, jsonData);
        // 안드로이드 저장 버전
        CreateJsonFile(Application.persistentDataPath, jsonName, jsonData);
        Debug.Log("Json생성 : " + jsonName);
        Debug.Log(strBPos);
    }
    string ObjectToJson(object obj) {
        return JsonUtility.ToJson(obj);
    }
    void CreateJsonFile(string createPath, string fileName, string jsonData) {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create, FileAccess.Write);
        Debug.Log(string.Format("{0}/{1}.json", createPath, fileName));
        byte[] data = Encoding.UTF8.GetBytes(jsonData.ToString());
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}
public class PosJsonClass {
    public string pos;

    public PosJsonClass(string pos) {
        this.pos = pos;
    }
}