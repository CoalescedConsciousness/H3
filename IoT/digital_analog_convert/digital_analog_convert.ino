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
int timer = 50;
char str[3];

void setup() {
  Serial.begin(9600);
  lcd.begin(16, 2);

}

void popLcd()
{
  lcd.setCursor(0,0);
  lcd.write("R");
  lcd.setCursor(6,0);
  lcd.write("G");
  lcd.setCursor(12,0);
  lcd.write("B");
}
void loop() {
  // module1();
  // module2();
  module3();
}
// 13.3:
void module3()
{
  popLcd();
 
  int prevColor;
  int firstColor;
  for (int i = 0; i < sizeof(RGB); i++)
  {
    // if (i > 0)
    // {
    //   prevColor = i-1;
    // }
    // if (prevColor > 0)
    // {
    //   firstColor = prevColor - 1;
    // }

    for (int x = 0; x <= 255; x++)
    {
      lcd.setCursor((i * 6)+1, 0);
      sprintf(str, "%d", x);
      lcd.write(str);
      analogWrite(RGB[i], x);
      
      if (i > 0)
      {
        iterSecond(i-1,x);
      }
      delay(timer);
    }
  }
  
}

void iterSecond(int LED, int frequency)
{
  analogWrite(RGB[LED], 255-(frequency/2));
  lcd.setCursor(((LED) * 6)+1, 0);
  int y = 255-(frequency/2);
  sprintf(str, "%d", y);
  lcd.write(str);
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