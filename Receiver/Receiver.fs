open RabbitMQ.Client
open RabbitMQ.Client.Events

let ReceiveMessages () =
    seq {
        let connFac = new ConnectionFactory ()
        use conn = connFac.CreateConnection "localhost"
        use chan = conn.CreateModel ()
        let queue = chan.QueueDeclare "hello"

        let consumer = new QueueingBasicConsumer (chan)
        let consumeString = chan.BasicConsume ("hello", null, consumer)
        while true do
            let event = (consumer.Queue.Dequeue() :?> BasicDeliverEventArgs)
            yield (event.Body |> System.Text.Encoding.UTF8.GetString)
    }

printfn "Listening, press ctrl-C to stop..."
ReceiveMessages ()
|> Seq.map (fun m -> printfn "%A" m)
|> Seq.toList
|> ignore

