Dnsk - dotnet starter kit
=========================

This project is the basic starting point for my dotnet based projects, 
revolving around the primary technologies:

* Client - Blazor WASM
* Server - Aspnet core with RPC pattern
* DB - Ef core


To build and run unit tests:
```bash
./bin/pre
```
or:
```bash
./bin/pre nuke
```
to delete all containers and start again, useful if there is a db schema change

To build and run the app:
```bash
./bin/run
```
or:
```bash
./bin/run nuke
```
to delete all containers and start again, useful if there is a db schema change