# Code Review Exercise #

This repository includes a C# console application that showcases the refactor needed to improve a logger implementation code snippet from an exercise. It also includes a unit test project with tests for the main business logic. The detailed feedback is included in [this document](./feedback/Feedback.md).


### Application configuration ###

Open the **App.config** file from the CodeReviewExercise project and update the following settings:

**App Settings**

- **LogSources**: comma separated list of sources to use (e.g. ConsoleLogger, TextFileLogger, SqlDatabaseLogger)
- **LogVerbosity**: integer that represents the log type (e.g. Error (1), Warning (2), Message (3)). If Error type is specified, only errors will be logged. If Warning type is specified, errors and warnings will be logged. If message type is specified, errors, warnings and messages will be logged.
- **LogFileDirectory**: path to a directory where the logs will be stored when using the Text File Logger

**Connection Strings**

- **LogDbConnectionString**: the connection string to a database that will be used by the Sql Database logger to store logs.

Below is an example of a configuration that uses all the supported loggers, sets the general application verbosity to _Error_, stores logs in a log file within the _C:\temp_ directory and uses the _CodeReviewExercise_ database:

```
<connectionStrings>
    <add name="LogDbConnectionString" providerName="System.Data.SqlClient" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=CodeReviewExercise;Integrated Security=SSPI;" />
</connectionStrings>
<appSettings>
    <add key="LogSources" value="ConsoleLogger, TextFileLogger, SqlDatabaseLogger" />
    <add key="LogVerbosity" value="1" />
    <add key="LogFileDirectory" value="C:\temp" />
</appSettings>
```

### Usage ###

In a command-line terminal type:

`CodeReviewExercise.exe "{message-to-log}" "{message-verbosity-type-number}"`

Examples:

- The following command will log an error with the message _This is an error_ (if the configuration allows to do so): 

	`CodeReviewExercise.exe "This is an error" "1"`

- The following command will log a warning with the message _This is a warning_ (if the configuration allows to do so): 

	`CodeReviewExercise.exe "This is a warning" "2"`

- The following command will log a message _Hello World!_ (if the configuration allows to do so): 

	`CodeReviewExercise.exe "Hello World!" "3"`
