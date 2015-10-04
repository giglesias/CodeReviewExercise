# Feedback for Code Review exercise #

This document describes all the feedback encountered in the provided code snippet related to logging messages to different sources.


## Compilation errors ##

The code snippet didn't compile in the first place. After adding the **JobLogger.cs** class as-is in a new C# Console application, the following errors were raised:

![compilation-errors](./images/compilation-errors.png)

The **LogMessage** method cannot receive two parameters with the same name but different type. In order to fix this, we'll rename the _message_ bool parameter to _shouldLogMessage_ along with the usages along the method. To keep these convention, we'll also rename both the _warning_ and _error_ bool parameters to _shouldLogWarning_ and _shouldLogError_ correspondingly. After this update, the method's contract should look as the following one:

```
public static void LogMessage(string message, bool shouldLogMessage, bool shouldLogWarning, bool shouldLogError)
```

If we compile the code again, we are still receiving compilation errors, as the _t_ and _l_ variables are not initialized before using them.

![compilation-errors-2](./images/compilation-errors-2.png)

In order to quickly fix this, we'll initialize both variables as follows:

```
...

int t = 0;

...

string l = null;

...
```

After these changes, the code built successfully.

## Refactor ##

This section describes the general refactor that was required to meet the SOLID principles in object-oriented programming for the provided code snippet.

