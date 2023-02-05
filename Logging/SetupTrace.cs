using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

[SetUpFixture]
public class SetupTrace
{
    [OneTimeSetUp]
    public void StartTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

        log4net.GlobalContext.Properties["LogFileName"] = $"{ProjectDirectory()}{Path.DirectorySeparatorChar}TestResults{Path.DirectorySeparatorChar}";
        string pokus = $"{ProjectDirectory()}{Path.DirectorySeparatorChar}log4net.config";
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