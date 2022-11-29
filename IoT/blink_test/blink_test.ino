#include "alphabet.h"
#include "translator.h"

String response;

void setup() 
{
  pinMode(PIN_LED, OUTPUT);
  Serial.begin(9600);
}

void loop() 
{
  while(Serial.available())
  {
    response = Serial.readString();
    decipherString(response);
  }
}

void decipherString(String input)
{
  // Iterate through the input string; note that EOL char falls through resulting switch case, but EOL still takes up a character in the string.
  for (int i = 0; i <= input.length(); i++) 
  {
    Serial.println(input[i]);
    translate(input[i]); // Calls translate() which sends the Char through a switch-case
  }
}