/* EEPROM
 * There are 16 buttons and so 32 possible events
 * The EEPROM is 1024 Bytes so each string associated with each event is allowed up to 32 Bytes (1024/32 = 32)
 * The EEPROM structure will therefor be organised into 32, 32 Byte blocks.
 * The address for the string of each button event can be calculated in the following way:
 * 
 * For button press events:
 * Index = 32 * Button index (where index ranges from 0 - 15)
 * 
 * For button release events:
 * Index = (1024/2) + 32 * Button index (where index ranges from 0 - 15)
 */


#include "Keyboard.h"
#include <EEPROM.h>
#include "SerialCommand.h"

#define EEPROM_SIZE 1024
#define EEPROM_BLOCK_SIZE       (EEPROM_SIZE/32)
#define EEPROM_PRESS_INDEX(x)   (x * EEPROM_BLOCK_SIZE)
#define EEPROM_RELEASE_INDEX(x) ((EEPROM_SIZE / 2) + (EEPROM_BLOCK_SIZE * x))

#define BUTTON_COUNT 16
#define INPUT_READ_TIMEOUT 50

String buttonPress[BUTTON_COUNT];
String buttonRelease[BUTTON_COUNT];

int button_LUT[BUTTON_COUNT] = {2,3,4,5,6,7,9,8,A3,A2,A1,A0,10,16,14,15};

bool button_state[BUTTON_COUNT];


typedef enum {
	kPress = 1,
	kRelease = 2
} buttonEvent_t;

void eepromReadString(unsigned int button, buttonEvent_t event);
bool eepromWriteString(String str, unsigned int button, buttonEvent_t event);

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

  // Setup callbacks for SerialCommand commands
  sCmd.addCommand("*IDN?", info);
  sCmd.addCommand("BUTTONS?", query_button_count);
  sCmd.addCommand("PRESS?", query_press);
  sCmd.addCommand("RELEASE?", query_release);
  sCmd.addCommand("SET:PRESS", set_press);
  sCmd.addCommand("SET:RELEASE", set_release);
  sCmd.addCommand("EEPROM:READ", eeprom_read);
  sCmd.addCommand("EEPROM:ERASE", eeprom_erase);
  sCmd.setDefaultHandler(unrecognized);      // Handler for command that isn't matched  (says "What?")

  /* Start timers */
  setTimer(&readInputTimer);
  
  delay(1000);  // delay required otherwise this function doesnt get called?
  
  eeprom_read();
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

void query_button_count() {
  Serial.println(BUTTON_COUNT);
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
		buttonPress[button] = arg;	// save 
		eepromWriteString(arg, button, kPress);	// write to EEPROM
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
		buttonRelease[button] = arg;	// save 
		eepromWriteString(arg, button, kRelease);	// write to EEPROM
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

bool eepromWriteString(String str, unsigned int button, buttonEvent_t event)
{
	if ((button < BUTTON_COUNT) && (str.length() <= EEPROM_BLOCK_SIZE))
	{
		unsigned int address;

		if (event == kPress)
			address = EEPROM_PRESS_INDEX(button);
		else if (event == kRelease)
			address = EEPROM_RELEASE_INDEX(button);
		else
			return false;
		
		for (int i = 0; i < str.length(); i++) 
    {
			EEPROM.write(address + i, str[i]);	// This stores the 'i'th character of your string as a byte on the 'i'th address of the EEPROM 
    }
    EEPROM.write(address + str.length(), '\0');  // Add a string terminator

		return true;
	}
	return false;
}

void eepromReadString(unsigned int button, buttonEvent_t event)
{
	char str[EEPROM_BLOCK_SIZE] = "";

	if (button < BUTTON_COUNT)
	{
		unsigned int address;

		if (event == kPress)
			address = EEPROM_PRESS_INDEX(button);
		else if (event == kRelease)
			address = EEPROM_RELEASE_INDEX(button);

		char str[EEPROM_BLOCK_SIZE];

		for (int i = 0; i < EEPROM_BLOCK_SIZE; i++)
		{
			str[i] = EEPROM.read(address + i);
			if (str[i] == '\0')
				break;
		}

    if (event == kPress)
      buttonPress[button] = str;
    else if (event == kRelease)
      buttonRelease[button] = str;
	}
}

void eeprom_read(void)
{
  for (int i=0; i<BUTTON_COUNT; i++)
  {
    eepromReadString(i, kPress);
    eepromReadString(i, kRelease);
  }
}

void eeprom_erase(void)
{
  for (int i=0; i<EEPROM_SIZE; i++)
  {
    if (i%EEPROM_BLOCK_SIZE == 0)
      EEPROM.write(i, '\0');
    else
      EEPROM.write(i, 0xFF);
  }
  Serial.println("OK");
}

