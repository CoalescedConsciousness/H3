// Initialize global variables x and y
int x = 0;
int y = 0;

void setup() 
{
  Serial.begin(9600);
  // Initialize digital pin LED_BUILTIN as an output
  pinMode(LED_BUILTIN, OUTPUT);
}


void loop() 
{
  digitalWrite(LED_BUILTIN, HIGH);   // Turn the LED on
  x++;                               // Increment in one unit x
  y--;                               // Decrement in one unit y
  printToConsole();
  delay(2000);                       // Wait for a second

  digitalWrite(LED_BUILTIN, LOW);    // Turn the LED off 
  delay(200);                       // Wait for a second
}

void printToConsole()
{
  Serial.print("x = ");Serial.println(x);
  Serial.print("y = ");Serial.println(y);
}