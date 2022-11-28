void setup() 
{
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(2, OUTPUT);
}

// the loop function runs over and over again forever
void loop() 
{
  s(2);
  o(2);
  s(2);
  delay(2000);
}

void s(int output)
{
  for (int i = 0; i < 3; i++)
  {
    digitalWrite(output, HIGH);
    delay(200);
    digitalWrite(output, LOW);
    delay(200);
  }
}

void o(int output)
{
  for (int i = 0; i < 3; i++)
  {
    digitalWrite(output, HIGH);
    delay(400);
    digitalWrite(output, LOW);
    delay(400);
  }
}