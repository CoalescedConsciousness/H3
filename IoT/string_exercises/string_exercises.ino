int intArr[] = {7, 9, 13};
String h = "Hello";
String f = "Friends";
char n[] = "Mads";
void setup() {
  Serial.begin(9600);
  // for (int i = 0; i < 8; i++)
  // {
  //   Serial.println(intArr[i]);
  // }
  for (int i = sizeof(n)-2; i >= 0; i--)
  {
    Serial.println(n[i]);
  }

}

void loop() {

}
