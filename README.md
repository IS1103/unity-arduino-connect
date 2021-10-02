# Unity And Arduino Connector 

## 說明
可以快速在 Unity3D 連接 Arduino 的小插件。

## Unity ArduinoConnector.cs

設定後拖拉到物件上:
```C#
public int baud; //包率
public string portName; //portName
```

取得 arduino 的資料:
```C#
ArduinoConnector arduinoConnector;
arduinoConnector.receiveEvent = ReceiveEvent;

...

//監聽 arduino 發送的訊息啊
void ReceiveEvent(string msg){
    Debug.Log(msg);//A
}
```

發送 unity 的訊號給 arduino:
```C#
ArduinoConnector arduinoConnector;
arduinoConnector.writeEvent("C");
```
## Arduino 
```C
void setup() {
  Serial.begin(9600);//設定包率
}

void loop() {
    Serial.println("A");//送訊息到 port
    char a = Serial.read();//從 unity 接收資料
}
```
