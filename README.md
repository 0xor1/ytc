Dnsk - dotnet starter kit
=========================

[LIVE DEMO](https://dnsk.dans-demos.com)

This project is the basic starting point for my dotnet based projects, 
revolving around the primary technologies:

* Client - Blazor WASM
* Server - Aspnet core with RPC pattern
* DB - Ef core

### Prerequisites

To build and run this project you need `.net core 8`, `docker` and `docker-compose` installed.

To build and run unit tests:
```bash
./bin/pre
```
To build and run the app:
```bash
./bin/run
```
You can pass parameter `nuke` to either `./bin/pre` or `./bin/run` to delete
docker containers and rebuild them, this is typically useful if there has been a db schema change.