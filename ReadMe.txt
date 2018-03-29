Hi,

Super cool that you guys are following the microservice pattern :) 
Ive been working alot with .net core and REALLY enjoying what it has to offer.

I loved seeing microsoft providing its own dependency injection container along with logging, the best part is that you can implement another logging solution into it!
Needless to say JSON configuration is simply the best way forward . web.config is great and all but JSON is a whole new level.

Thanks for the challenge had alot of fun with this bad boy! Please see some notes(thoughts) below about my implementation !

*Microservice? No problem , I found this great little lib at https://github.com/PeterKottas/DotNetCore.WindowsService . This guy did a topshelf like integration for core. Whats the point of having a microservice if you cant install a DLL? Come on! We need self recovery!
*Two console apps - one that emits the message , sticks it to a queue on the exchange and one consumer who handles the message. Basic stuff yo >:) (writing as i code btw)
*Lets Create a Service class library that will handle all the business logic . The heavy lifting is done in here to keep the complexity away from the console applications. Neat. Each Console application will have to handle its on dependency injection .
*Just used the boiler plate code for rabbit mq , pretty straight forward stuff
*I used the rabbtimqadmin plugin along with my dev testing.
*There you go you can install the DLL as a windows service with the action:install in cmd
