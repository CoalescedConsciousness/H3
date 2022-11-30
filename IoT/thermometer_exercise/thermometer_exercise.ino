#include <LiquidCrystal.h>
#define THERMO A5
#define LED_1 8
#define DELAY 500
#define LOW_TEMP 21
#define HIGH_TEMP 23
int STATE = LOW;
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);


void setup() {
  lcd.begin(16, 2);
}

void loop() {
  double measurement = measureTemp(analogRead(THERMO));
  if (LOW_TEMP < measurement < HIGH_TEMP)
  {
    digitalWrite(LED_1, HIGH);
  }
  else { digitalWrite(LED_1, LOW); }
  delay(DELAY);


}

double measureTemp(double res)
{
  lcd.setCursor(0,0);
  lcd.print(res);
  double temp = log(10000.00 * (1024/res - 1));
  double tempK = 1/ ( 0.001129148 + (0.000234125 + (0.0000000876741 * temp * temp)) * temp);
  lcd.setCursor(9, 0);
  lcd.print(temp);
  lcd.setCursor(0, 1);
  lcd.print(tempK);
  lcd.print("K");

  double tempC = tempK - 273.15;
  lcd.setCursor(9, 1);
  lcd.print(tempC);
  lcd.print((char)223);
  return tempC;
}


