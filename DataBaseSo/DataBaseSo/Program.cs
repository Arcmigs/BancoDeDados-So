using DatabaseSo;
using System.IO.Pipes;
using Newtonsoft.Json;

namespace DataBaseSO
{
    class Client
    {
        static void Main(string[] args)
        {
            using (var client = new NamedPipeClientStream("my_pipe"))
            {
                client.Connect();

                using (var reader = new StreamReader(client))
                using (var writer = new StreamWriter(client))
                {
                    var message = new Message();
                    switch (args[0])
                    {
                        case "--insert":
                            message.Op = Operation.Insert;
                            message.Key = int.Parse(args[1]);
                            message.Value = args[2];
                            break;
                        case "--get":
                            message.Op = Operation.Get;
                            message.Key = int.Parse(args[1]);
                            break;
                        case "--update":
                            message.Op = Operation.Update;
                            message.Key = int.Parse(args[1]);
                            message.Value = args[2];
                            break;
                        case "--remove":
                            message.Op = Operation.Remove;
                            message.Key = int.Parse(args[1]);
                            break;
                        default:
                            Console.WriteLine("Invalid command. Use '--insert', '--get', '--update', or '--remove'.");
                            return;
                    }

                    string requestJson = JsonConvert.SerializeObject(message);
                    writer.WriteLine(requestJson);
                    writer.Flush();

                    string responseJson = reader.ReadLine();
                    var responseMessage = JsonConvert.DeserializeObject<Message>(responseJson);

                    Console.WriteLine(responseMessage.Value);
                }
            }
        }
    }
}