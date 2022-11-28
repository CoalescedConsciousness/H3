#include <Arduino.h>

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