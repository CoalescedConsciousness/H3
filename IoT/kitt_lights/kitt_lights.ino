#define LEDS 4
#define START 2

void setup() {
  for (int i = 2; i < LEDS + 2; i++)
  {
    pinMode(i, OUTPUT);
  }
  Serial.begin(9600);
}

void loop() {
  for (int i = START; i < (LEDS + START); i++)
  {
    blink(i);
  }
  for (int i = (LEDS + START); i > START; i--)
  {
    blink(i);
  }
}

void blink(int led)
{
    digitalWrite(led, HIGH);
    delay(100);
    digitalWrite(led, LOW);
    delay(20);
}