#define LED_1 9
int incomingByte;

void setup() {
  Serial.begin(9600);
  Serial.print("--");
  pinMode(LED_1, OUTPUT);
}

void loop() {
  getText();
  module1();
}

// 19.5:
void getText()
{
  if (Serial.available() > 0)
    {
      incomingByte = Serial.read();
      if (48 <= incomingByte && incomingByte <= 57)
      {
        blinkLED((incomingByte - 48));
      }
    }
}

void blinkLED(int cycle)
{
  cycle *= 100;
  digitalWrite(LED_1, HIGH);
  delay(cycle);
  digitalWrite(LED_1, LOW);
}

// 19.2:
void module1()
{
  // reply only when you receive data:
	if (Serial.available() > 0)
	{
		// read the incoming byte from Buffer:
		incomingByte = Serial.read();

		// say what you got:
		Serial.print("I received: ");
		Serial.print((char)incomingByte);
		Serial.print(" = 0x");
		Serial.println(incomingByte, HEX);
	}
}