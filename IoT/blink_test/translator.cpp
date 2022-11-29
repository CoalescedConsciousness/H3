#include <Arduino.h>
#include "alphabet.h" // Morse encoding library

// Finds the equivalent char and calls the appropriate function from alphabet.cpp, which in turn executes the correct morse encoding for that char.
void translate(char letter)
{
  switch(letter) 
  {
    case 'a':
    a();
    break;

    case 'b':
    b();
    break;
    
    case 'c':
    c();
    break;
    
    case 'd':
    d();
    break;
    
    case 'e':
    e();
    break;
    
    case 'f':
    f();
    break;
    
    case 'g':
    g();
    break;

    case 'h':
    h();
    break;

    case 'i':
    i();
    break;

    case 'j':
    j();
    break;

    case 'k':
    k();
    break;

    case 'l':
    l();
    break;

    case 'm':
    m();
    break;

    case 'n':
    n();
    break;

    case 'o':
    o();
    break;

    case 'p':
    p();
    break;

    case 'q':
    q();
    break;

    case 'r':
    r();
    break;

    case 's':
    s();
    break;

    case 't':
    t();
    break;

    case 'u':
    u();
    break;

    case 'v':
    v();
    break;

    case 'w':
    w();
    break;

    case 'x':
    x();
    break;

    case 'y':
    y();
    break;

    case 'z':
    z();
    break;

    default:
    break;
  }
}