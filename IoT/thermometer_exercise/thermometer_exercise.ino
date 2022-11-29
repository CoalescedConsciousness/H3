#include <LiquidCrystal.h>
#define POTENT A5
#define LED_1 8
int STATE = LOW;
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);


void setup() {
  lcd.begin(16, 2);
}

void loop() {
  int res = analogRead(POTENT);
  delay(res);
  digitalWrite(LED_1, STATE);
  STATE = !STATE;
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(res);
}


