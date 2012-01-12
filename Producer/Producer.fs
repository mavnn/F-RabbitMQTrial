open RabbitMQ.Client
open RabbitMQ.Util

let sendMessage (message : string) =
    let connFac = new ConnectionFactory ()
    use conn = connFac.CreateConnection "localhost"
    use chan = conn.CreateModel ()
    let queue = chan.QueueDeclare "hello"

    chan.BasicPublish ("", "hello", null, message |> System.Text.Encoding.UTF8.GetBytes)

let message = "Hello world!"

sendMessage message
printf "Sent message: %A" message
