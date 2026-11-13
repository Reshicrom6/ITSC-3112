namespace Exercise13_2_1.Service;

public class Logger
{
    
    private static Logger? _instance = null;
    private string path = "../../SingletonLog.txt";
    private Logger(){}

    public static Logger GetInstance()
    {
        if (_instance == null) { _instance = new Logger(); }
        return _instance;
    }

    public void Info(string message)
    {
        File.AppendAllText(path, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture)} [INFO] {message}{Environment.NewLine}");
    }

    public void Warn(string message)
    {
        File.AppendAllText(path, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture)} [WARN] {message}{Environment.NewLine}");
    }

    public void Error(string message)
    {
        File.AppendAllText(path, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture)} [ERROR] {message}{Environment.NewLine}");
    }
}
