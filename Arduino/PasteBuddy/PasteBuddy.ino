
#include "Keyboard.h"
#include "SerialCommand.h"

#define BUTTON_COUNT 16
#define INPUT_READ_TIMEOUT 50

String buttonPress[BUTTON_COUNT];
String buttonRelease[BUTTON_COUNT];

int button_LUT[BUTTON_COUNT] = {2,3,4,5,6,7,9,8,A3,A2,A1,A0,10,16,14,15};

bool button_state[BUTTON_COUNT];

unsigned long	runTime = 0,
				readInputTimer = 0;


SerialCommand sCmd;

void setup() {
  // initialize control over the keyboard:
  Keyboard.begin();

  // setup GPIO for 13 buttons 
  for (int i=0; i<BUTTON_COUNT; i++)
    pinMode(button_LUT[i], INPUT_PULLUP);

  Serial.begin(115200);

  // Initialise strings - temporary measure, will eventually pull from eeprom
  for (int i = 0; i<BUTTON_COUNT; i++)
  {
	  buttonPress[i] = "Press_" + String(i);
	  buttonRelease[i] = "Release_" + String(i);
  }

  // Setup callbacks for SerialCommand commands
  sCmd.addCommand("*IDN?", info);
  sCmd.addCommand("PRESS?", query_press);
  sCmd.addCommand("RELEASE?", query_release);
  sCmd.addCommand("SET:PRESS", set_press);
  sCmd.addCommand("SET:RELEASE", set_release);
  sCmd.setDefaultHandler(unrecognized);      // Handler for command that isn't matched  (says "What?")

  /* Start timers */
  setTimer(&readInputTimer);
}

void loop() 
{
	// Process any incomming serial commands
	sCmd.readSerial();

	/* Periodically read the inputs */
	if (timerExpired(readInputTimer, INPUT_READ_TIMEOUT)) // check for button press periodically
	{
		setTimer(&readInputTimer);  // reset timer
		readButtons();
	}
}

void readButtons(void)
{
  static bool last_button_state[BUTTON_COUNT];


  for (int i=0; i<BUTTON_COUNT; i++)
  {
    // store the current state
    last_button_state[i] = button_state[i];
    // read the new state
    button_state[i] = !digitalRead(button_LUT[i]);
    // check for rising edge (button press)
    if (!last_button_state[i] && button_state[i])
      buttonPressed(i);
    // check for falling edge (button release)
    if (last_button_state[i] && !button_state[i])
      buttonReleased(i);
  }
}

void buttonPressed(int button)
{
  // switch case here to perform action corresponding to button press of each button
	Keyboard.println(buttonPress[button]);
	Keyboard.write('\n');
}

void buttonReleased(int button)
{
  // switch case here to perform action corresponding to button release of each button
  Keyboard.println(buttonRelease[button]);
  Keyboard.write('\n');
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
}

// This gets set as the default handler, and gets called when no other command matches.
void unrecognized(const char *command) {
	Serial.println("What?");
}

/* pass this function a pointer to an unsigned long to store the start time for the timer */
void setTimer(unsigned long *startTime)
{
	runTime = millis();    // get time running in ms
	*startTime = runTime;  // store the current time
}

/* call this function and pass it the variable which stores the timer start time and the desired expiry time
returns true fi timer has expired */
bool timerExpired(unsigned long startTime, unsigned long expiryTime)
{
	runTime = millis(); // get time running in ms
	if ((runTime - startTime) >= expiryTime)
		return true;
	else
		return false;
}
