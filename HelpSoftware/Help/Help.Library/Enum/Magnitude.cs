namespace Help.Library
{
  public enum Magnitude
  {
    //Not Defined. Needs to be defined as soon as possible
    NaN = 0,

    //No Output the Log is turned off for all debug and info but warn will be logged and error
    None = 1,

    //The info will be logged but no debug
    Minimum = 3,

    //the Debug and Info and Warn and Error will be logged
    Debug = 7,

    //The Database will be logged as Database Logger -> Will produce a lot of Log so be carefull
    Developement = 10
  }
}