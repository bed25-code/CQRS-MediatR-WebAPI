# CQRS-MediatR-WebAPI

This repository is a beginner-friendly demonstration of different ways to build ASP.NET Core Web APIs, using the same dog domain so the architecture differences are easy to compare.

## Projects in this repository

- `SimpleWebApi`  
  A plain Web API project using simple controller + service logic (no CQRS, no MediatR, no clean architecture).

- `CQRSWebApi`  
  A single Web API project that demonstrates CQRS with explicit commands, queries, and handlers, without MediatR.

- `MediatR_CQRSWebAPI`  
  A CQRS Web API that uses MediatR for request/handler dispatching.

## Solution file

- `Clean-API.sln` is located at the repository root and includes:
  - `SimpleWebApi`
  - `CQRSWebApi`
  - `MediatR_CQRSWebAPI`

## Domain used for examples

All demo projects use the same `Dog` model concept (`Id`, `Name`) to keep the focus on architecture and request handling style rather than business complexity.

## Purpose

Use this repository to demonstrate:

1. Standard service-based API flow
2. CQRS flow (commands and queries with dedicated handlers)
3. CQRS with and without MediatR
4. How request handling changes between simple and structured approaches
