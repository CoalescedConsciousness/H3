void setup() {
  Serial.begin(9600);

  int a = 2;
  int b = 3;
  int result;
  int *pA = &a;
  int *pB = &b;
  int *pResult = &result;

  result = *pA + *pB;
  Serial.println();
  Serial.print((unsigned int)*pA);
  Serial.print(" + ");
  Serial.print((unsigned int)*pB);
  Serial.print(" = ");
  Serial.print((unsigned int)*pResult);
}

void loop() {
  // put your main code here, to run repeatedly:

}
