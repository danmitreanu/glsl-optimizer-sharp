FROM ubuntu:24.04 AS builder

RUN apt update && apt install -y \
	cmake \
	g++ \
	gcc \
	g++-aarch64-linux-gnu \
	gcc-aarch64-linux-gnu \
	make \
	build-essential \
	libc6-dev

