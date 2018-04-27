// Demo Code for SerialCommand Library
// Steven Cogswell
// May 2011

#include <SerialCommand.h>
#define TOTAL_BUTTONS 16

SerialCommand sCmd;     // The demo SerialCommand object

String buttonPress[TOTAL_BUTTONS];
String buttonRelease[TOTAL_BUTTONS];

void setup() {
  Serial.begin(115200);

  for (int i=0; i<TOTAL_BUTTONS; i++)
  {
    buttonPress[i] = "Press_example" + String(i);
    buttonRelease[i] = "Release_example" + String(i);
  }

  // Setup callbacks for SerialCommand commands
  sCmd.addCommand("*IDN?",    info);
  sCmd.addCommand("PRESS?",    query_press);
  sCmd.addCommand("RELEASE?",    query_release);
  sCmd.addCommand("SET:PRESS",     set_press);
  sCmd.addCommand("SET:RELEASE",     set_release);
  sCmd.setDefaultHandler(unrecognized);      // Handler for command that isn't matched  (says "What?")
}

void loop() {
  sCmd.readSerial();     // We don't do much, just process serial commands
}

void info()
{
  Serial.println("PasteBuddy"); // return name
}

void query_press() {
  char *arg;
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) {    // As long as it existed, take it
    int button = atoi(arg);   
    Serial.println(buttonPress[button]);
  }
  else {
    Serial.println("ERR");
  }
}

void query_release() {
  char *arg;
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) {    // As long as it existed, take it
    int button = atoi(arg);   
    Serial.println(buttonRelease[button]);
  }
  else {
    Serial.println("ERR");
  }
}

void set_press() 
{
  char *arg;
  int button;
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) 
  {    // As long as it existed, take it
    button = atoi(arg);   
  }
  else 
  {
    Serial.println("ARDerror");
  }
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) 
  {    // As long as it existed, take it
    buttonPress[button] = arg;   
    Serial.println("OK");
  }
  else 
  {
    Serial.println("ERR");
  }
  sCmd.clearBuffer();
}

void set_release() 
{
  char *arg;
  int button;
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) 
  {    // As long as it existed, take it
    button = atoi(arg);   
  }
  else 
  {
    Serial.println("ERR");
  }
  arg = sCmd.next();    // Get the next argument from the SerialCommand object buffer
  if (arg != NULL) 
  {    // As long as it existed, take it
    buttonRelease[button] = arg;   
    Serial.println("OK");
  }
  else 
  {
    Serial.println("ERR");
  }
  sCmd.clearBuffer();
}
/*

void processCommand() {
  int aNumber;
  char *arg;

  Serial.println("We're in processCommand");
  arg = sCmd.next();
  if (arg != NULL) {
    aNumber = atoi(arg);    // Converts a char string to an integer
    Serial.print("First argument was: ");
    Serial.println(aNumber);
  }
  else {
    Serial.println("No arguments");
  }

  arg = sCmd.next();
  if (arg != NULL) {
    aNumber = atol(arg);
    Serial.print("Second argument was: ");
    Serial.println(aNumber);
  }
  else {
    Serial.println("No second argument");
  }
}
*/

// This gets set as the default handler, and gets called when no other command matches.
void unrecognized(const char *command) {
  Serial.println("What?");
}
