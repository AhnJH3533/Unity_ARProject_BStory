using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GB_CreateWaypoints : MonoBehaviour {
    public string jsonName = "WayPointPosition";
    List<Vector3> listWayPos;
    public GameObject point;
    void Start() {
        listWayPos = new List<Vector3>();
    }
    public void ReadJson() {
        //var jtc2 = LoadJsonFile<PosJsonClass>(Application.dataPath, jsonName);
        // 안드로이드 버전 경로 수정
        var jtc2 = LoadJsonFile<PosJsonClass>(Application.persistentDataPath, jsonName);
        Debug.Log(jtc2.pos);

        string temp = jtc2.pos;

        string[] posDatas = temp.Split('|');
        foreach (var s in posDatas) {
            Debug.Log("**   " + s);
        }

        List<string[]> posList = new List<string[]>();
        foreach (var s in posDatas) {
            posList.Add(s.Split(','));
        }
        foreach (var p in posList) {
            foreach (var s in p) {
                Debug.Log(s);
            }
            listWayPos.Add(new Vector3(float.Parse(p[0]), float.Parse(p[1]) - 1f, float.Parse(p[2])));
        }
        foreach (var s in listWayPos) {
            Debug.Log(s);
        }
    }
    public void CreatePoints() {
        foreach (var pos in listWayPos) {
            Instantiate(point, pos, Quaternion.identity).transform.parent = this.transform;
        }
    }
    T LoadJsonFile<T>(string loadPath, string fileName) {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
}
