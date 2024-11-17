Ytc - YouTubeContained
======================
[![Build Status](https://github.com/0xor1/ytc/actions/workflows/build.yml/badge.svg)](https://github.com/0xor1/ytc/actions/workflows/build.yml)
[![Coverage Status](https://coveralls.io/repos/github/0xor1/ytc/badge.svg)](https://coveralls.io/github/0xor1/ytc)
[![Demo Live](https://img.shields.io/badge/demo-live-4ec820)](https://ytc.dans-demos.com)

YouTubeContained is a YT wrapper app that aims to make YT a safer healthier app to use:

* Whilst watching a video no other UI is shown, this prevents getting distracted whilst watching, by either comments or other video suggestions
* Comments and Shorts will never be shown
* Search results UI can be configured to hide any info the user doesn't want including thumbnails to reduce clickbait exposure
* Search will have ability to filter on time ranges as well as key words
* no homescreen with "suggestions"

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