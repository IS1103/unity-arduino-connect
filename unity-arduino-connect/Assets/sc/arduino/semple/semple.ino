#define pinBtn 8
#define pinOut 13

void setup() {
  pinMode(pinBtn, INPUT_PULLUP);
  pinMode(pinOut, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  int btn = digitalRead(pinBtn);
  char a = Serial.read();
  
  if(a == '1'){
    Serial.println("C");
  }else if (btn == LOW) {
    digitalWrite(pinOut, HIGH);
    Serial.println("A");
  }
  else {
    digitalWrite(pinOut, LOW);
    Serial.println("B");
  }
  delay(1000);
}
