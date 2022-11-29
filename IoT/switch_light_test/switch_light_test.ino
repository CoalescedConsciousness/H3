#define LED_1 2
#define SWITCH_1 3

int LastCheck = LOW;
int SHEEP = 0;
int LightState = LOW;

unsigned long lastBounce = 0;
unsigned long bounce = 50;

void setup()
{
  pinMode(LED_1, OUTPUT);
  pinMode(SWITCH_1, INPUT);
  Serial.begin(9600);
}

void loop() {
  int reading = digitalRead(SWITCH_1);
  if (reading != LastCheck)
  {
    lastBounce = millis();
  }

  if ((millis() - lastBounce) > bounce)
  {
    if (!reading)
    {
      if (LastCheck == LOW)
      {
        LightState = !LightState;
        digitalWrite(LED_1, LightState);
        SHEEP++;
        Serial.println("INCREASED");
        Serial.println(SHEEP);
      }
      LastCheck = HIGH;
    }
    else
    {
      LastCheck = LOW;
    }
  }
}
