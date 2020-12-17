using Socket.Newtonsoft.Json;
using Socket.Quobject.SocketIoClientDotNet.Client;
using System.Collections.Generic;
//using System.Web.Script.Serialization;
using UnityEngine;


public class SocketUser : MonoBehaviour
{
    private QSocket socket;
    public PlayerMotor playerMotor;
    public class UIDAnswer
    {
        public string uid { get; set; }
    }
    public class UpdateSend
    {
        public string id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float angle { get; set; }
        public bool shot { get; set; }
    }
    public class ObstacleInfo
    {
        public float x { get; set; }
        public float y { get; set; }
        public float width { get; set; }
        public float length { get; set; }
    }
    public class PlayerInfo
    {
        public float x { get; set; }
        public float y { get; set; }
        public float angle { get; set; }
        public int hp { get; set; }
        public string id { get; set; }
    }

    public class PlayerList
    {
        public List<PlayerInfo> players { get; set; }
        public List<object> @event { get; set; }
    }

    UIDAnswer uidget = null;
    public string id = "";
    void Start()
    {
        List<ObstacleInfo> map = new List<ObstacleInfo>();
        foreach(GameObject wall in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            ObstacleInfo obs = new ObstacleInfo();
            obs.x = wall.transform.position.x;
            obs.y = wall.transform.position.z;
            obs.width = wall.transform.localScale.x;
            obs.length = wall.transform.localScale.z;
            map.Add(obs);
        }
        //Debug.Log(JsonConvert.SerializeObject(map));
        Debug.Log("start");
        socket = IO.Socket("http://127.0.0.1:5000/");

        socket.On(QSocket.EVENT_CONNECT, () => {
            Debug.Log("Connected");
            socket.Emit("generate_new_player", @"{""uid"":0}");
        });
        socket.On("error", () => { 
            Debug.Log("error disconnect");
            socket.Disconnect();
        }) ;
        socket.On("stub", data => {
            //Debug.Log("stub data");
            //Debug.Log("stub data : " + data);
        });
        socket.On("uid", data => {
            uidget = JsonConvert.DeserializeObject<UIDAnswer>(data.ToString());
            id = uidget.uid;
        });
        socket.On("update", data => {
            //Debug.Log("update data : " + data);
            PlayerList list = JsonConvert.DeserializeObject<PlayerList>(data.ToString());
            Vector3 pos = new Vector3();
            pos.x = list.players[0].x;
            pos.y = 0.5f;
            pos.z = list.players[0].y;
            playerMotor.UpdatePosition(pos);
        });
        
    }

    void OnGUI()
    {
        
        //if (GUI.Button(new Rect(20, 70, 150, 30), "SEND"))
        //{
        //    UpdateEvent(1f, 1f, 0f, false);
        //    //playerMotor.UpdaetePosition(new Vector3(-2f, 0.5f, -2f));
        //}
    }

    void OnDestroy()
    {
        Debug.Log("disc");
        socket.Disconnect();
    }
    // Update is called once per frame
    public void UpdateEvent(float x, float y, float angle, bool shoot)
    {
        if (uidget != null)
        {
            UpdateSend data = new UpdateSend();
            data.id = uidget.uid;
            data.x = x;
            data.y = y;
            data.angle = angle;
            data.shot = shoot;
            string res = JsonConvert.SerializeObject(data);
            
            socket.Emit("update", res);

        }
    }
}
