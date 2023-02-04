using log4net;
using log4net.Config;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;

[SetUpFixture]
public class SetupTrace
{
    [OneTimeSetUp]
    public void StartTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

        log4net.GlobalContext.Properties["LogFileName"] = $"{ProjectDirectory()}\\TestResults\\";
        string pokus = $"{ProjectDirectory()}\\log4net.config";
        var log4netFilleInfo = new FileInfo(pokus);
        log4net.Config.XmlConfigurator.Configure(log4netFilleInfo);
        ProjectDirectory();
    }
    /// <summary>
    /// Get project directory absolute path 
    /// e.g.: "C:\\Users\\vojte\\source\\repos\\AlzaTest\\"
    /// </summary>
    /// <param name="path"></param>
    private string ProjectDirectory()
    {
        List<string> pathSegments = TestContext.CurrentContext.TestDirectory.Split('\\').ToList<string>();
        var projectDirPathIndex = pathSegments.FindLastIndex(x => x == "AlzaTest");
        string projectDirectory = string.Join("\\", pathSegments.Take<string>(projectDirPathIndex + 1));
        Console.WriteLine(projectDirectory);
        return projectDirectory;
    }

    [OneTimeTearDown]
    public void EndTest()
    {
        Trace.Flush();
    }
}