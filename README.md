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

## Lab 14 Update
So I think that I have added in everything but the HotelRoomController. I can not check this because the 
IIS server will not run. With some help from Kjell (sorry if I got your name wrong) I was able to figure out
that the https server was going to 55133 which is in a restricted range of ports for me but can not find any
way to change that port. We both tried to troubleshoot that but they had to catch a bus and I did not get
inspiration afterwards so I did the coding as best I could without being able to run the server.

## Lab 18 and 19 update
Alright, I think I have everything linked up for the users in the database and all that jazz. Had to throw in some boilerplate ID properties into 
some of the models to get the dotnet migration process to work but I am focusing on the Authentification side of things. Over the weekend I will circle back to that,
I think the problem is tied to not setting up the links between all the models corectly.
