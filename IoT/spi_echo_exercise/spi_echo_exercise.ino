void setup() {
  Serial1.begin(9600);
  // Serial.begin(9600);
  Serial1.print('A');
}

void loop() {
  // while(Serial.available())
  // {
  //   String response = Serial.readString();
  //   decipherString(response);
  // }

}
void decipherString(String input)
{
  for (int i = 0; i <= input.length(); i++) 
  { // Calls translate() which sends the Char through a switch-case
    Serial1.write(input[1]);
  }
}