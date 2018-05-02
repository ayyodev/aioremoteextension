# aioremoteextension
This is an open source remote web management server and extension for [AIOMiner](https://aiominer.com)
Check out the first version of the [server](https://aioremoteserverdev.azurewebsites.net).

## Server Stack
- .NET Core
- SQLite
- SignalR Core
- DotnNetify

## Client extension
- WPF MVVM
- SignalR Core Client on .NET Standard
- WPF MaterialDesign

### How to use
- Create an account on the [server](https://aioremoteserverdev.azurewebsites.net)
- Download the client from releases
- Unzip it into the root of the AIOMiner folder
- Run AioRemoteExtension.exe
- Enter your username and workername and connect
- Go to the Dashboard on the server
 
### How to Host
- Download the server
- Build it
- Download the client from releases, unzip into AIOMiner root
- Modify ServerUrl in AioRemoteExtension.config to your host (Eg: htttp://yourhost/WorkersHub)
