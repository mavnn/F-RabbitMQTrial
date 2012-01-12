# RabbitMQ in F#

A (literally) 'Hello world!" level example of using RabbitMQ
via F#, created in Mono. There's no reason it shouldn't work
under .net as well.

## To use

Clone and build Producer and Receiver. Receiver will receive until
interrupted, and each time Producer is run at will send "Hello world!"
to the queue Receiver is listening to.
