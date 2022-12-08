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

// OLED:
#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 64 // OLED display height, in pixels
#define TZ -1  // To adjust for timezone differences.
#define OLED_RESET 4 // Reset pin # (or -1 if sharing Arduino reset pin)

Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);
RTC_DS3231 rtc;
DHT dht(DHTPIN, DHTTYPE);

char daysOfTheWeek[7][12] = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
int counter = 0;
int page = HIGH;

void setup () {
  Serial.begin(9600);
  dht.begin();
// #ifndef ESP8266
//   while (!Serial); // wait for serial port to connect. Needed for native USB
// #endif

// Check for OLED:
  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) 
	{ // Address for 128x64
		Serial.println(F("SSD1306 allocation failed"));
		for(;;); // Don't proceed, loop forever
	}

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
void loop() 
{
  display.clearDisplay();
  
  display.setTextColor(BLACK,WHITE);
	display.setCursor(0,0); // Start at top-left corner
  display.setFont();  

  // Changes the "page" in 3 second intervals, based purely on DateTime second, rather than delay().
  if (rtc.now().second() % 3 == 0)
  {
    page = !page;
  }
  page ? rtcCycle() : dhtCycle();

  // Scroll 
  display.startscrollright(0,14);
	delay(1000);
  display.stopscroll();
 
  
}

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
  display.display();
}
// Function for repeating code used to check whether or not value needs a leading zero (i.e. is below 10)
void checkLeadingZero(int value)
{
  if (value < 10) { display.print(0); }
  display.print(value, DEC);
}