#include <Arduino.h>
#define PIN_LED 2

void dot()
{
  digitalWrite(PIN_LED, HIGH);
  delay(200);
  digitalWrite(PIN_LED, LOW);
  delay(200);
}
void dash()
{
  digitalWrite(PIN_LED, HIGH);
  delay(400);
  digitalWrite(PIN_LED, LOW);
  delay(400);
}

void a() {dot(); dash();}
void b() {dash(); dot(); dot(); dot();}
void c() {dash(); dot(); dash(); dot();}
void d() {dash(); dot(); dot();}
void e() {dot();}
void f() {dot(); dot(); dash(); dot();}
void g() {dash(); dash(); dot();}
void h() {dot(); dot(); dot(); dot();}
void i() {dot(); dot();}
void j() {dot(); dash(); dash(); dash();}
void k() {dash(); dot(); dash();}
void l() {dot(); dash(); dot(); dot();}
void m() {dash(); dash();}
void n() {dash(); dot();}
void o() {dash(); dash(); dash();}
void p() {dot(); dash(); dash(); dot();}
void q() {dash(); dash(); dot(); dash();}
void r() {dot(); dash(); dot();}
void s() {dot(); dot(); dot();}
void t() {dash();}
void u() {dot(); dot(); dash();}
void v() {dot(); dot(); dot(); dash();}
void w() {dot(); dash(); dash();}
void x() {dash(); dot(); dot(); dash();}
void y() {dash(); dot(); dash(); dash();}
void z() {dash(); dash(); dot(); dot();}