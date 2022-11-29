#define LED_1 2
#define SWITCH_1 3

void setup()
{
  pinMode(LED_1, OUTPUT);
  pinMode(SWITCH_1, INPUT);
  Serial.begin(9600);
}

void loop() {
  Serial.println(digitalRead(SWITCH_1));
  digitalRead(SWITCH_1) ? digitalWrite(LED_1, HIGH) : digitalWrite(LED_1, LOW);
}
