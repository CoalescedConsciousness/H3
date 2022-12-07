#include <Servo.h>
#include <LiquidCrystal.h>
#define LED_1 10
#define SWITCH_1 7
volatile int STATE = LOW;
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

Servo servo; // create servo object to control a servo
int val; 
int pos = 0;  
int thermPIN = A5;

void setup() {
  lcd.begin(16,2);
  servo.attach(9); // PIN 9
  pinMode(LED_1, OUTPUT);
  pinMode(SWITCH_1, INPUT_PULLUP);

  attachInterrupt(digitalPinToInterrupt(SWITCH_1), detectSwitch, RISING);
  
}
 
void loop() {
  // setTempPos();
  sweepF();
  sweepB();
  delay(55);

}
// Exercise 18:
void detectSwitch()
{
  digitalWrite(LED_1, STATE);
  STATE = !STATE;
}

// Exercise 17:
void setTempPos()
{
  double temp = analogRead(thermPIN);
  pos = map(temp, 0, 1023, 0, 180);
  lcd.setCursor(0,0);
  lcd.print(pos);
  servo.write(pos);
}

void sweepF() {
  for (pos = 0; pos <= 180; pos++)
  {
    servo.write(pos);
    delay(25);

  }
}

void sweepB() {
  for (pos = 180; pos >= 0; pos--)
  {
    servo.write(pos);
    delay(25);

  }
}
