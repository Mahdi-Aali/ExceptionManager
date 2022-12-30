using System.Text;

namespace ExceptionManagment.ExceptionUtilities;

public static class ExceptionLogger
{
    public static void LogConsole(Exception ex)
    {
        Console.WriteLine("********** Error **********");
        Console.WriteLine("=> Message: {0}", ex.Message);
        Console.WriteLine("=> Help link: {0}", ex.HelpLink);
        Console.WriteLine("=> Exception source: {0}", ex.Source);
        Console.WriteLine("=> Target site: {0}", ex.TargetSite);
        Console.WriteLine("=> Member type: {0}", ex?.TargetSite?.MemberType);
        Console.WriteLine("=> Declaring type: {0}", ex?.TargetSite?.DeclaringType);
        Console.WriteLine("=> Type name: {0}", ex?.TargetSite?.Name);
        Console.WriteLine("=> Stack trace: {0}", ex?.StackTrace);
        Console.WriteLine("=> Throw date and time: {0}", DateTime.Now);
        Console.WriteLine("********** End Error **********");
    }

    public static async Task LogToFileAsync(Exception ex, string filePath)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(ex);
            ArgumentNullException.ThrowIfNull(filePath);
            if (IsFileValid(filePath))
            {
                await File.AppendAllTextAsync(filePath, GetExceptionDetail(ex));
            }
            else
            {
                LogConsole(ex!);
            }
        }
        catch (Exception e)
        {
            LogConsole(e);
        }
    }

    public static void LogToFile(Exception ex, string filePath)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(ex);
            ArgumentNullException.ThrowIfNull(filePath);
            if (IsFileValid(filePath))
            {
                File.AppendAllText(filePath, GetExceptionDetail(ex));
            }
            else
            {
                LogConsole(ex);
            }
        }
        catch (Exception e)
        {
            LogConsole(e);
        }
    }


    private static bool IsFileValid(string filePath)
    {
        return File.Exists(filePath) && Path.GetExtension(filePath).Equals(".txt");
    }

    private static string GetExceptionDetail(Exception ex)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("\n********** Error **********");
        stringBuilder.AppendLine($"=> Message: {ex.Message}");
        stringBuilder.AppendLine($"=> Help link: {ex.HelpLink}");
        stringBuilder.AppendLine($"=> Exception source: {ex.Source}");
        stringBuilder.AppendLine($"=> Target site: {ex.TargetSite}");
        stringBuilder.AppendLine($"=> Member type: {ex?.TargetSite?.MemberType}");
        stringBuilder.AppendLine($"=> Declaring type: {ex?.TargetSite?.DeclaringType}");
        stringBuilder.AppendLine($"=> Type name: {ex?.TargetSite?.Name}");
        stringBuilder.AppendLine($"=> Stack trace: {ex?.StackTrace}");
        stringBuilder.AppendLine($"=> Throw date and time: {DateTime.Now}");
        stringBuilder.AppendLine("********** End Error **********\n");
        return stringBuilder.ToString();
    }
}
