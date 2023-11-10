using System.IO;
using System.IO.Pipes;
using Newtonsoft.Json;

namespace ServerDatabaseSo
{
    class Server
    {
        static void Main(string[] args)
        {
            var database = new KeyValueDatabase(args[0]);

            using (var server = new NamedPipeServerStream("my_pipe"))
            {
                server.WaitForConnection();

                using (var reader = new StreamReader(server))
                using (var writer = new StreamWriter(server))
                {
                    while (true)
                    {
                        string requestJson = reader.ReadLine();
                        var requestMessage = JsonConvert.DeserializeObject<Message>(requestJson);

                        var responseMessage = database.HandleRequest(requestMessage);
                        string responseJson = JsonConvert.SerializeObject(responseMessage);

                        writer.WriteLine(responseJson);
                        writer.Flush();
                    }
                }
            }
        }
    }
}