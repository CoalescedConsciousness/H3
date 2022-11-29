#include <LiquidCrystal.h>
#define POTENT A5
#define LED_1 8
int STATE = LOW;
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

void setup()
{
  pinMode(LED_1, OUTPUT);
  Serial.begin(9600);
}
void loop() {
  int res = analogRead(POTENT);
  Serial.println(res);
  delay(res);
  digitalWrite(LED_1, STATE);
  STATE = !STATE;

}
byte customChar0[8] =
{
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b00110,
  0b01111,
  0b11111,
  0b11111
};

byte customChar1[8] =
{
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b01100,
  0b11110,
  0b11111,
  0b11111,
};

byte customChar2[8] =
{
  0b11111,
  0b01111,
  0b00111,
  0b00011,
  0b00001,
  0b00000,
  0b00000,
  0b00000
};

byte customChar3[8] =
{
  0b11111,
  0b11110,
  0b11100,
  0b11000,
  0b10000,
  0b00000,
  0b00000,
  0b00000
};

byte customChar4[8] =
{
  0b10000,
  0b11000,
  0b11100,
  0b11110,
  0b11111,
  0b11111,
  0b10001,
  0b01001
};

byte customChar5[8] =
{
  0b00001,
  0b00011,
  0b00111,
  0b01111,
  0b11111,
  0b11111,
  0b10001,
  0b10010
};

byte customChar6[8] =
{
  0b01111,
  0b00111,
  0b00011,
  0b00010,
  0b00001,
  0b00000,
  0b00000,
  0b00000
};

byte customChar7[8] =
{
  0b11110,
  0b11100,
  0b11000,
  0b01000,
  0b10000,
  0b00000,
  0b00000,
  0b00000
};

// void setup() {
//   lcd.createChar(0, customChar0);
//   lcd.createChar(1, customChar1);
//   lcd.createChar(2, customChar2);
//   lcd.createChar(3, customChar3);
//   lcd.createChar(4, customChar4);
//   lcd.createChar(5, customChar5);
//   lcd.createChar(6, customChar6);
//   lcd.createChar(7, customChar7);
//   lcd.begin(16, 2);
//   lcd.write(byte(0));
//   lcd.write(byte(1));
//   lcd.write(byte(4));
//   lcd.write(byte(5));
//   lcd.setCursor(0, 1);
//   lcd.write(byte(2));
//   lcd.write(byte(3));

 
//   lcd.write(byte(6));
//   lcd.write(byte(7));
// }


