# ExceptionManager

This package provide three method for logging in detail for you

1. LogConsole
2. LogToFile
3. LogToFileAsync

## LogConsole
- This method will log exception detail in console command prompt

### Example of ```LogConsole(Exception ex)``` method

```C#
using ExceptionManagment.ExceptionUtilities;

namespace YourProjectNameSpace;

internal class Program
{
    private static void Main()
    {
        WriteString(null!);
    }
    
    private static void WriteString(string text)
    {
         try
        {
            ArgumentNullException.ThrowIfNull(text);
            Console.WriteLine(text);
        }
        catch (Exception ex)
        {
            ExceptionLogger.LogConsole(ex);
        }
    }
}
```

The result will appear like this in console command prompt

```
********** Error **********
=> Message: Value cannot be null. (Parameter 'text')
=> Help link: 
=> Exception source: System.Private.CoreLib
=> Target site: Void Throw(System.String)
=> Member type: Method
=> Declaring type: System.ArgumentNullException
=> Type name: Throw
=> Stack trace:    at System.ArgumentNullException.Throw(String paramName)
   at System.ArgumentNullException.ThrowIfNull(Object argument, String paramName)
   at Program.<<Main>$>g__WriteString|0_0(String text) in D:\Drive F\MyConsoleApplication\MyConsoleApplication\Program.cs:line 16
=> Throw date and time: 12/30/2022 1:00:24 PM
********** End Error **********
```

### Example of ```LogToFile(Exception ex, string filePath)``` method

```C#
using ExceptionManagment.ExceptionUtilities;

namespace YourProjectNameSpace;

internal class Program
{
    private static void Main()
    {
        WriteString(null!);
    }
    
    private static void WriteString(string text)
    {
         try
        {
            ArgumentNullException.ThrowIfNull(text);
            Console.WriteLine(text);
        }
        catch (Exception ex)
        {
            ExceptionLogger.LogToFile(ex, "D:/LogFile.txt");
        }
    }
}
```

### Example of ```LogToFileAsync(Exception ex, string filePath)``` method

```C#
using ExceptionManagment.ExceptionUtilities;

namespace YourProjectNameSpace;

internal class Program
{
    private static async Task Main()
    {
        await WriteStringAsync(null!);
    }
    
    static async Task WriteStringAsync(string text)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(text);
            WriteLine(text);
        }
        catch (Exception ex)
        {
            await ExceptionLogger.LogToFileAsync(ex, "D:/LogFile.txt");
        }
    }
}
```

The results of those two method will appear like this in log file

```

********** Error **********
=> Message: Value cannot be null. (Parameter 'text')
=> Help link: 
=> Exception source: System.Private.CoreLib
=> Target site: Void Throw(System.String)
=> Member type: Method
=> Declaring type: System.ArgumentNullException
=> Type name: Throw
=> Stack trace:    at System.ArgumentNullException.Throw(String paramName)
   at System.ArgumentNullException.ThrowIfNull(Object argument, String paramName)
   at Program.<<Main>$>g__WriteStringAsync|0_1(String text) in D:\Drive F\MyConsoleApplication\MyConsoleApplication\Program.cs:line 31
=> Throw date and time: 12/30/2022 1:04:19 PM
********** End Error **********
```
