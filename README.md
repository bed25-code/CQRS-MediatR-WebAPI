# CQRS-MediatR-WebAPI

This repository is a beginner-friendly demonstration of different ways to build ASP.NET Core Web APIs, using the same dog domain so the architecture differences are easy to compare.

## Projects in this repository

- `SimpleWebApi`  
  A plain Web API project using simple controller + service logic (no CQRS, no MediatR, no clean architecture).

- `CQRSWebApi`  
  A single Web API project that demonstrates CQRS with commands and queries, using MediatR and an in-memory mock database.

- `MediatR_CQRSWebAPI`  
  A copy of the CQRS + MediatR approach for additional experimentation and comparison.

- `Clean-CQRS-API`  
  The original Clean Architecture example project that was cloned as the baseline reference.

## Solution file

- `Clean-API.sln` is located at the repository root and includes all projects.

## Domain used for examples

All demo projects use the same `Dog` model concept (`Id`, `Name`) to keep the focus on architecture and request handling style rather than business complexity.

## Purpose

Use this repository to demonstrate:

1. Standard service-based API flow
2. CQRS flow (commands vs queries)
3. MediatR request/handler pipeline
4. How project structure changes from simple to more structured styles
