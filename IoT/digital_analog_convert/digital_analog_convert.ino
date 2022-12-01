#include <LiquidCrystal.h>
#define ANALOG_! A5
#define LED_1 8
#define DELAY 500
#define LOW_TEMP 21
#define HIGH_TEMP 23
int STATE = LOW;
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);
byte RGB[] = {6, 9, 10};
int timer = 10;

void setup() {
  // lcd.begin(16, 2);
}

void loop() {
  // module1();
  // module2();
  module3();
}
// 13.3:
void module3()
{
  for (int i = 0; i < sizeof(RGB); i++)
  {
    for (int x = 0; x <= 255; x++)
    {
      analogWrite(RGB[i], x);
      delay(timer);
    }
  }
}
// 13.2:
void module2()
{
  analogWrite(7, 127); 
}


// 13.1
void module1() {
  int val = 255;
  while (!val < 1)
  {
    analogWrite(LED_1, val);
    val *= 0.75;
    delay(DELAY);
    lcd.setCursor(13,0);
    lcd.print(val);
  }
}