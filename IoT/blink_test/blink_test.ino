#include "alphabet.h"
#define PIN_LED 2

String response;

void setup() 
{
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(PIN_LED, OUTPUT);
  Serial.begin(9600);

}

// the loop function runs over and over again forever
void loop() 
{
  //  while(Serial.available()) {

  //   a= Serial.readString();// read the incoming data as string

  //   Serial.println(a); 
  //  }
  
  while(Serial.available())
  {
    response = Serial.readString();
    decipherString(response);
      
    // s(PIN_LED);
    // o(PIN_LED);
    // s(PIN_LED);
    // delay(2000);
  }

}

void decipherString(String input)
{
  Serial.print(input.length());
  for (int i = 0; i <= input.length(); i++) 
  {
    // Call morse letter
    Serial.println(i);
    Serial.print(input[i]);
  }
}