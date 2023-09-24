#!/usr/bin/env bash

# Build locally
docker build --tag tetrisv2-api .

# Build for remote & push to server
docker build --tag docker.swijnenburg.cc/tetrisv2-api .
docker push docker.swijnenburg.cc/tetrisv2-api

# Remove intermediate/untagged images
docker image prune -f