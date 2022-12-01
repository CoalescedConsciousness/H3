int intArr[] = {7, 9, 13};
String h = "Hello";
String f = "Friends";
char n[] = "Mads";
void setup() {
  Serial.begin(9600);
  Serial.println();
  //module1();
  module2();

}

void loop() {

}
void module2()
{
  Serial.println(h);
  Serial.println(h.length());
  Serial.println(f);
  Serial.println(f.length());
  String x;
  Serial.println(h + ' ' + f);
  Serial.println(f.charAt(2)); // i
}
void module1()
{
    for (int i = 0; i < 8; i++)
  {
    Serial.println(intArr[i]);
  }
  for (int i = sizeof(n)-2; i >= 0; i--)
  {
    Serial.println(n[i]);
  }
}