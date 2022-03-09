namespace HalloSingelton
{
    public class Logger
    {
        private static Logger? _instance;
        private static object _instanceLock = new();
        public static Logger Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
                return _instance;
            }
        }

        private Logger()
        {
            Console.WriteLine("Neue Logger Instance");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:d} {DateTime.Now:t} {msg}");
        }
    }
}
