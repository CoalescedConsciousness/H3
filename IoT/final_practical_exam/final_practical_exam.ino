// Date and time functions using a DS3231 RTC connected via I2C and Wire lib
#include "RTClib.h"
/* Simpel demo af OLED LCD Display med I2C */
#include <SPI.h>
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>
#include "DHT.h"
#include <Fonts/FreeSerif9pt7b.h>

// DHT:
#define DHTPIN 2
#define DHTTYPE DHT11

// Control switches (buttons)
#define B1 LOW
#define B2 LOW
#define B3 LOW

// OLED:
#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 64 // OLED display height, in pixels
#define TZ -1  // To adjust for timezone differences.
#define OLED_RESET 4 // Reset pin # (or -1 if sharing Arduino reset pin)

// Instantiate devices:
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);
RTC_DS3231 rtc;
DHT dht(DHTPIN, DHTTYPE);

char daysOfTheWeek[7][12] = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

// Variables used to control states as part of switch functionality
int page = HIGH;
int bg = HIGH;
int s2Function = HIGH;

// Arrays used for switch, state and clock setting controls.
const int arrSwitch[] = {3,11,5};
int arrState[] = {HIGH, HIGH, HIGH};
int arrClock[] = {LOW, LOW, LOW};
int prevClock = 4;

// Debouncing:
unsigned long lastBounce = 0;
unsigned long bounce = 50;

void setup () {
  Serial.begin(9600);
  dht.begin();
  display.setTextColor(WHITE);

// Initiate button PINs and add Interrupt for each.
  for (int i = 0; i < sizeof(arrSwitch)/4; i++) // /3 due to int datatype size
  {
    pinMode(arrSwitch[i], INPUT);
  }
  attachInterrupt(digitalPinToInterrupt(arrSwitch[0]), changeBG, CHANGE);
  attachInterrupt(digitalPinToInterrupt(arrSwitch[1]), changeFunction, CHANGE);
  attachInterrupt(digitalPinToInterrupt(arrSwitch[2]), changeTime, CHANGE);

// Check for OLED:
  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) 
	{ // Address for 128x64
		Serial.println(F("SSD1306 allocation failed"));
		for(;;); // Don't proceed, loop forever
	}

// Check for RTC:
  if (! rtc.begin()) {
    Serial.println("Couldn't find RTC");
    Serial.flush();
    while (1) delay(10);
  }

  if (rtc.lostPower()) {
    Serial.println("RTC lost power, let's set the time!");
    rtc.adjust(DateTime(F(__DATE__), F(__TIME__)));
  }
}

// Function "belonging" to 1st button (arrSwitch[0]). Determines either BACKGROUND COLOUR or PAGE, depending on the state of s2Function, determined by changeFunction() below.
void changeBG()
{
  int reading = digitalRead(arrSwitch[0]);
  if (reading != arrState[0])
  {
    lastBounce = millis();
  }

  if ((millis() - lastBounce) > bounce)
  {
    if (!reading)
    {
      if (arrState[0] == LOW)
      {
        if (s2Function)
        {
          bg = !bg;
          if (bg == HIGH)
          {
            display.setTextColor(BLACK, WHITE);
          }
          if (bg == LOW)
          {
            display.setTextColor(WHITE);
          }
        }
        else {
         page = !page;
        }
      }
      arrState[0] = HIGH;
    }
    else
    {
      arrState[0] = LOW;
    }
  }
}

// Function "belonging" to 2nd button (arrSwitch[1]). Determines the exact function of the two other switches (arrSwitch[0] and arrSwitch[2]), making a total of 4 possible "functions" (practically speaking) 
void changeFunction()
{
  // Serial.println("CHANGE FUNCTION");
  int reading = digitalRead(arrSwitch[1]);
  // Serial.println(reading);
  if (reading != arrState[1])
  {
    lastBounce = millis();
  }

  if ((millis() - lastBounce) > bounce)
  {
    if (!reading)
    {
      if (arrState[1] == LOW)
      {
        s2Function = !s2Function;
      }
      arrState[1] = HIGH;
    }
    else
    {
      arrState[1] = LOW;
    }
  }
}

//
void changeTime()
{
  int reading = digitalRead(arrSwitch[2]);
  Serial.println(reading);
  if (reading != arrState[2])
  {
    lastBounce = millis();
  }

  if ((millis() - lastBounce) > bounce)
  {
    if (!reading)
    {
      if (arrState[2] == LOW)
      {
        if (s2Function)
        {
          DateTime now = rtc.now();
          rtc.adjust(DateTime(now.year(), now.month(), now.day(), arrClock[0] ? now.hour()+1 : now.hour(), arrClock[1] ? now.minute() + 1 : now.minute(), arrClock[2] ? now.second() + 1 : now.second()));
          Serial.println("Changed time");
          if (!arrClock[0] && !arrClock[1] && !arrClock[2])
          {
            rtc.adjust(DateTime(F(__DATE__), F(__TIME__)));
          }
        }
        else {
          Serial.println("PREVIOUS CLOCK:");
          Serial.print(prevClock);
          if (prevClock == 4)
          {
            arrClock[0] = HIGH;
            prevClock = 0;
          }
          else if (prevClock == 2)
          {
            arrClock[2] = LOW;
            prevClock = 4; // 4 is used to reset clock to connected computer time.
          }
          else {
            arrClock[prevClock] = LOW;
            prevClock++;
            arrClock[prevClock] = HIGH;
          }
          Serial.println("Changed target");
        }
      }
      arrState[2] = HIGH;
    }
    else
    {
      arrState[2] = LOW;
    }
  }
}

void loop() 
{
  display.clearDisplay();
	display.setCursor(0,0); // Start at top-left corner
  display.setFont();  

  page ? rtcCycle() : dhtCycle(); 
  
  // Scroll 
  // display.startscrollright(0,14);
	delay(1000);
  // display.stopscroll();
 
  
}

// The display configuration for data provided by the DHT
void dhtCycle()
{
  // display.setFont(&FreeSerif9pt7b); // Corrupts alignment when switching between different fonts, apparently.
  display.setTextSize(2);
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  display.print("T: ");
  display.print(t);
  display.print((char)247);
  display.println();
  display.print("H: ");
  display.print(h);
  display.print("%");
  display.display();
}

// The display configuration for the data provided by the RTC
void rtcCycle()
{
  DateTime now = rtc.now();
  display.setTextSize(2);
	display.setFont();
  // Print the name of the current day of the week:
  display.print(daysOfTheWeek[now.dayOfTheWeek()]);
  display.println();

  // DATE
  checkLeadingZero(now.day());
  display.print('/');
  checkLeadingZero(now.month());
  display.print('/');
  display.print(now.year(), DEC);
  display.println();

  // TIME
  checkLeadingZero(now.hour()+TZ);
  display.print(':');
  checkLeadingZero(now.minute());
  display.print(':');
  checkLeadingZero(now.second());
  display.println();

  // TEMP
  display.setTextSize(1);
  float temp = rtc.getTemperature();
  display.print("Temp: ");
  display.print(temp);
  display.print((char)247);
  display.println();
  
  // Button states:
  display.print("Setter: ");
  display.print(prevClock);
  display.print(" Function: ");
  display.print(s2Function);
  display.display();

}

// Function used to check whether or not value needs a leading zero (i.e. is below 10)
void checkLeadingZero(int value)
{
  if (value < 10) { display.print(0); }
  display.print(value, DEC);
}