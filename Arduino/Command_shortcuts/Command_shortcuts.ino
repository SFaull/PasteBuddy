/*
 * button map:
 * 0 -> standby
 * 1 -> footswitch
 * 2 -> timer up
 * 3 -> timer down
 * 4 -> bargraph inc
 * 5 -> bargraph dec
 * 6 -> timer set
 * 7 -> bargraph set
 * 8 -> standby?
 * 9 -> supply?
 * 10 -> display?
 * 11 -> bargraph?
 * 12 -> wash?
 */

#include "Keyboard.h"
#define BUTTON_COUNT 16  // number of connected buttons

/* Action commands */
String standby_press = "REM:SBY:P";
String standby_release = "REM:SBY:R";
String footswitch_press = "REM:FS:P";
String footswitch_release = "REM:FS:R";
String timer_up_press = "REM:UP:P";
String timer_up_release = "REM:UP:R";
String timer_down_press = "REM:DWN:P";
String timer_down_release = "REM:DWN:R";
String bargraph_inc_press = "REM:INC:P";
String bargraph_inc_release = "REM:INC:R";
String bargraph_dec_press = "REM:DEC:P";
String bargraph_dec_release = "REM:DEC:R";

String timer_set = "REM:TMR ";  // requires a time to be entered after
String bargraph_set = "REM:BG "; // requires a value to be entered after

/* Query Commands */
String query_standby = "REM:SBY?";
String query_supply = "REM:SUP?";
String query_display = "REM:DISP?";
String query_bargraph = "REM:BG?";
String query_wash = "REM:WASH?";

int button_LUT[BUTTON_COUNT] = {2,3,4,5,6,7,9,8,A3,A2,A1,A0,10,16,14,15};

// based on the above commands, 8 buttons are required for action commands (could make do with 6 if necessary)
//                              5 buttons are required for query commands
//  Total: 13 (or 11) buttons 

bool button_state[BUTTON_COUNT];

void setup() {
  // initialize control over the keyboard:
  Keyboard.begin();

  // setup GPIO for 13 buttons 
  for (int i=0; i<BUTTON_COUNT; i++)
    pinMode(button_LUT[i], INPUT_PULLUP);
}

void loop() {
    readButtons();
    delay(50);
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
  Serial.print(button);
  Serial.println(" Pressed");
  // switch case here to perform action corresponding to button press of each button
  switch(button)
  {
    case 0:
      Keyboard.println(standby_press);
    break;

    case 1:
      Keyboard.println(footswitch_press);
    break;

    case 2:
      Keyboard.println(timer_up_press);
    break;

    case 3:
      Keyboard.println(timer_down_press);
    break;

    case 4:
      Keyboard.println(bargraph_inc_press);
    break;

    case 5:
      Keyboard.println(bargraph_dec_press);
    break;

    case 6:
      Keyboard.println(timer_set);
      return;
    break;

    case 7:
      Keyboard.println(bargraph_set);
      return;
    break;

    case 8:
      Keyboard.println(query_standby);
    break;

    case 9:
      Keyboard.println(query_supply);
    break;

    case 10:
      Keyboard.println(query_display);
    break;

    case 11:
      Keyboard.print(query_bargraph);
    break;

    case 12:
      Keyboard.print(query_wash);
    break;

    default:
      // do nothing
      return;
    break;
  }
    Keyboard.write('\n');
}

void buttonReleased(int button)
{
  Serial.print(button);
  Serial.println(" Released");
  // switch case here to perform action corresponding to button release of each button
  switch(button)
  {
    case 0:
      Keyboard.println(standby_release);
    break;

    case 1:
      Keyboard.println(footswitch_release);
    break;

    case 2:
      Keyboard.println(timer_up_release);
    break;

    case 3:
      Keyboard.println(timer_down_release);
    break;

    case 4:
      Keyboard.println(bargraph_inc_release);
    break;

    case 5:
      Keyboard.println(bargraph_dec_release);
    break;

    default:
      // do nothing
      return;
    break;
  }
  Keyboard.write('\n');
}

