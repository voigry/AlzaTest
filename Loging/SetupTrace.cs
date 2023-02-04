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
    /// Get project directory absolute path independently on machine or OS
    /// e.g.: "C:\\Users\\vojte\\source\\repos\\AlzaTest\\"
    /// </summary>
    /// <param name="path"></param>
    private string ProjectDirectory()
    {
        //Find current test directory
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        //From test directory string create uri and split it to segments
        var tdUri = new Uri(testDirectory);
        var tdUriType = tdUri.GetType;
        List<string> tdSegments = tdUri.Segments.ToList<string>();
        //Find out the project name last index 
        var tdIndex = tdSegments.FindLastIndex(s => s == "AlzaTest/");
        //Use path combine to create absolute path for log4env
        var slkj = tdSegments.Take<string>(tdIndex + 1).ToArray<string>();
        var path = Path.Combine(tdSegments.Take<string>(tdIndex + 1).ToArray<string>());
        var sep = Path.DirectorySeparatorChar;

        

        List<string> pathSegmentsList = TestContext.CurrentContext.TestDirectory.Split(Path.DirectorySeparatorChar).ToList<string>();
        var projectDirPathIndex = pathSegmentsList.FindLastIndex(x => x == "AlzaTest");
        string projectDirectory = string.Join(Path.DirectorySeparatorChar, pathSegmentsList.Take<string>(projectDirPathIndex + 1));
        Console.WriteLine(projectDirectory);
        return projectDirectory;
    }

    [OneTimeTearDown]
    public void EndTest()
    {
        Trace.Flush();
    }
}