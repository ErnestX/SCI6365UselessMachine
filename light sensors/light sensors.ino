int numOfSensors = 6;
int sensors[6] = {14, 15, 16, 17, 18, 19};
int readings[6] = {NAN, NAN, NAN, NAN, NAN, NAN};  

void setup() {
  Serial.begin(9600);
  for (int i = 0; i < numOfSensors; i++) {
    pinMode(sensors[i], INPUT);
  }
}

void loop() {
  for (int i = 0; i < numOfSensors; i++) {
    readings[i] = analogRead(sensors[i]);
    Serial.print(readings[i]);
    Serial.print(" ");
  }
  Serial.println("");
  delay(200);
}
