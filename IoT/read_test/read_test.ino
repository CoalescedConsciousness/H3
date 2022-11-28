void setup() {
  Serial.begin(9600);
}

void loop() {
  int buttonState = analogRead(A0);
  Serial.println(buttonState);
  delay(1); 

}