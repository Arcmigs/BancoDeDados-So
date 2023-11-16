using System;
using System.IO;
using System.IO.Pipes;
using Newtonsoft.Json;
using System.Threading;

namespace ServerDatabaseSo
{
    class Server
    {
        static void Main(string[] args)
        {
            var database = new KeyValueDatabase(args[0]);

            while (true)
            {
                var server = new NamedPipeServerStream("my_pipe", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances);
                server.WaitForConnection();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    using (var reader = new StreamReader(server))
                    using (var writer = new StreamWriter(server))
                    {
                        string requestJson = reader.ReadLine();
                        var requestMessage = JsonConvert.DeserializeObject<Message>(requestJson);

                        var responseMessage = database.HandleRequest(requestMessage);
                        string responseJson = JsonConvert.SerializeObject(responseMessage);

                        writer.WriteLine(responseJson);
                        writer.Flush();
                    }

                    server.Close();
                });
            }
        }
    }
}
