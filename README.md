# Async Inn
Created by Charles Bofferding
7/27/2021

## Purpose
This project is designed to create a simple and effective relational database that 
can be used by the Asnc Inn hotel chain to manage information on their different
properties and rooms.

## ERD
[ERD](async-inn-erd.png)

This ERD shows the basic structure of the database
Hotel contains the information about individual hotel locations
Rooms contains information about what specific rooms will contain
Amenities is the different features that can be tied to rooms

## Lab 13 Update
The controllers no longer implement the database functions. Instead the controllers only call
the methods that are defined in the different services. These are defined by the interfaces
made for each different table.